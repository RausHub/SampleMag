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
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Samplesextended")]
    public class SamplesExtendedController : ApiControllerBaseExtended
    {
        public SamplesExtendedController(IDataRepositoryFactory dataRepositoryFactory, IUnitOfWork unitOfWork)
            : base(dataRepositoryFactory, unitOfWork) { }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            _requiredRepositories = new List<Type>() { typeof(Sample) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;
                var Samples = _SamplesRepository.GetAll().OrderByDescending(m => m.PublishDate).Take(6).ToList();

                IEnumerable<SampleViewModel> SamplesVM = Mapper.Map<IEnumerable<Sample>, IEnumerable<SampleViewModel>>(Samples);

                response = request.CreateResponse<IEnumerable<SampleViewModel>>(HttpStatusCode.OK, SamplesVM);

                return response;
            });
        }

        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            _requiredRepositories = new List<Type>() { typeof(Sample) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;
                var Sample = _SamplesRepository.GetSingle(id);

                SampleViewModel SampleVM = Mapper.Map<Sample, SampleViewModel>(Sample);

                response = request.CreateResponse<SampleViewModel>(HttpStatusCode.OK, SampleVM);

                return response;
            });
        }

        [AllowAnonymous]
        [Route("{page:int=0}/{pageSize=3}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            _requiredRepositories = new List<Type>() { typeof(Sample) };
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;
                List<Sample> Samples = null;
                int totalSamples = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    Samples = _SamplesRepository.GetAll()
                        .OrderBy(m => m.ID)
                        .Where(m => m.Title.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .ToList();
                }
                else
                {
                    Samples = _SamplesRepository.GetAll().ToList();
                }

                totalSamples = Samples.Count();
                Samples = Samples.Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

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
            _requiredRepositories = new List<Type>() { typeof(Sample) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

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
            _requiredRepositories = new List<Type>() { typeof(Sample) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
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
                        SampleDb.UpdateSample(Sample);
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
