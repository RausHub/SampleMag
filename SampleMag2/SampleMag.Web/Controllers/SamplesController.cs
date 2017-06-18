using AutoMapper;
using SampleMag.Data.Infrastructure;
using SampleMag.Data.Repositories;
using SampleMag.Entities;
using SampleMag.Web.Infrastructure.Core;
using SampleMag.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SampleMag.Web.Infrastructure.Extensions;
using SampleMag.Data.Extensions;

namespace SampleMag.Web.Controllers
{
    [Authorize(Roles = "User")]
    [RoutePrefix("api/Samples")]
    public class SamplesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Sample> _SamplesRepository;
        private readonly IEntityBaseRepository<User> _UserRepository;

        public SamplesController(IEntityBaseRepository<Sample> SamplesRepository, IEntityBaseRepository<User> UserRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _SamplesRepository = SamplesRepository;
            _UserRepository = UserRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var Samples = _SamplesRepository.GetAll().OrderByDescending(m => m.PublishDate).Take(10).ToList();

                IEnumerable<SampleViewModel> SamplesVM = Mapper.Map<IEnumerable<Sample>, IEnumerable<SampleViewModel>>(Samples);

                response = request.CreateResponse<IEnumerable<SampleViewModel>>(HttpStatusCode.OK, SamplesVM);

                return response;
            });
        }

        [AllowAnonymous]
        [Route("popular")]
        public HttpResponseMessage GetPopular(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var Samples = _SamplesRepository.GetAll().OrderByDescending(m => m.UpVoteCount).Take(10).ToList();

                IEnumerable<SampleViewModel> SamplesVM = Mapper.Map<IEnumerable<Sample>, IEnumerable<SampleViewModel>>(Samples);

                response = request.CreateResponse<IEnumerable<SampleViewModel>>(HttpStatusCode.OK, SamplesVM);

                return response;
            });
        }

        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var Sample = _SamplesRepository.GetSingle(id);

                SampleViewModel SampleVM = Mapper.Map<Sample, SampleViewModel>(Sample);

                response = request.CreateResponse<SampleViewModel>(HttpStatusCode.OK, SampleVM);

                return response;
            });
        }
        [AllowAnonymous]
        [Route("genre/{id:int}")]
        public HttpResponseMessage GetAllByGenre(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var Samples = _SamplesRepository.GetAllByGenre(id).ToList();

                IEnumerable<SampleViewModel> SamplesVM = Mapper.Map<IEnumerable<Sample>, IEnumerable<SampleViewModel>>(Samples);

                response = request.CreateResponse<IEnumerable<SampleViewModel>>(HttpStatusCode.OK, SamplesVM);

                return response;
            });
        }
        
        [Route("user")]
        public HttpResponseMessage GetAllByUser(HttpRequestMessage request, string username)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var User = _UserRepository.GetSingleByUsername(username);

                var Samples = _SamplesRepository.GetAllByUser(User.ID).ToList();

                IEnumerable<SampleViewModel> SamplesVM = Mapper.Map<IEnumerable<Sample>, IEnumerable<SampleViewModel>>(Samples);

                response = request.CreateResponse<IEnumerable<SampleViewModel>>(HttpStatusCode.OK, SamplesVM);

                return response;
            });
        }

        [AllowAnonymous]
        [Route("{page:int=0}/{pageSize=3}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Sample> Samples = null;
                int totalSamples = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    Samples = _SamplesRepository
                        .FindBy(m => m.Title.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalSamples = _SamplesRepository
                        .FindBy(m => m.Title.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    Samples = _SamplesRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalSamples = _SamplesRepository.GetAll().Count();
                }

                IEnumerable<SampleViewModel> SamplesVM = Mapper.Map<IEnumerable<Sample>, IEnumerable<SampleViewModel>>(Samples);

                PaginationSet<SampleViewModel> pagedSet = new PaginationSet<SampleViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalSamples,
                    TotalPages = (int)Math.Ceiling((decimal)totalSamples / currentPageSize),
                    Items = SamplesVM
                };

                response = request.CreateResponse<PaginationSet<SampleViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, SampleViewModel Sample)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var u = _UserRepository.GetSingleByUsername(Sample.User);                
                Sample.UserId = u.ID;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Sample newSample = new Sample();
                    newSample.UpdateSample(Sample);

                    _SamplesRepository.Add(newSample);

                    _unitOfWork.Commit();

                    // Update view model
                    Sample = Mapper.Map<Sample, SampleViewModel>(newSample);
                    response = request.CreateResponse<SampleViewModel>(HttpStatusCode.Created, Sample);
                }
                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, SampleViewModel Sample)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var SampleDb = _SamplesRepository.GetSingle(Sample.ID);
                    if (SampleDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Sample.");
                    else if( SampleDb.User.Username != Sample.User)
                    {
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Not your sample.");
                    }
                    else
                    {
                        SampleDb.UpdateSample(Sample);
                        _SamplesRepository.Edit(SampleDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<SampleViewModel>(HttpStatusCode.OK, Sample);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, SampleViewModel Sample)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var SampleDb = _SamplesRepository.GetSingle(Sample.ID);
                    if (SampleDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Sample.");
                    else
                    {
                        _SamplesRepository.Delete(SampleDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<SampleViewModel>(HttpStatusCode.OK, Sample);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("upvote")]
        public HttpResponseMessage Upvote(HttpRequestMessage request, SampleViewModel Sample)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var SampleDb = _SamplesRepository.GetSingle(Sample.ID);
                    if (SampleDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Sample.");
                    else
                    {
                        SampleDb.UpVoteCount++;
                        _SamplesRepository.Edit(SampleDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<SampleViewModel>(HttpStatusCode.OK, Sample);
                    }
                }

                return response;
            });
        }
    }
}