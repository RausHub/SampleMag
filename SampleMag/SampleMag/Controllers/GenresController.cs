using AutoMapper;
using SampleMag.Data.Infrastructure;
using SampleMag.Data.Repositories;
using SampleMag.Entity;
using SampleMag.Infrastructure.Core;
using SampleMag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleMag.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/genres")]
    public class GenresController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Music_Genre> _genresRepository;

        public GenresController(IEntityBaseRepository<Music_Genre> genresRepository, IEntityBaseRepository<Error> _errorRepository, IUnitOfWork _unitOfWork)
            : base(_errorRepository, _unitOfWork)
        {
            _genresRepository = genresRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var genres = _genresRepository.GetAll().ToList();

                IEnumerable<GenreViewModel> genresVM = Mapper.Map<IEnumerable<Music_Genre>, IEnumerable<GenreViewModel>>(genres);

                response = request.CreateResponse<IEnumerable<GenreViewModel>>(HttpStatusCode.OK, genresVM);

                return response;
            });
        }
    }
}
