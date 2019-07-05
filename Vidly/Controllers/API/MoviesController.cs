using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Repositories;
using Vidly.Repositories.Persistent;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private UnitOfWork unitOfWork;

        public MoviesController()
        {
            unitOfWork= new UnitOfWork(new ApplicationDbContext());
        }

        public IHttpActionResult GetMovies(string query = null)
        {
            return Ok(unitOfWork.Movies.GetMoviesWithQuery(query));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = unitOfWork.Movies.GetMovieWithId(id);
            if (movie == null)
                return NotFound();
            return Ok(movie);

        }

        [HttpPost]
        [Authorize(Roles = RoleName.canManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            int movieId = unitOfWork.Movies.CreateMovie(movieDto);

            unitOfWork.Complete();

            return Created(new Uri(Request.RequestUri + "/" + movieId), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.canManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            unitOfWork.Movies.UpdateMovie(id, movieDto);
            unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.canManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            unitOfWork.Customers.DeleteCustomer(id);
            unitOfWork.Complete();
            return Ok();
        }
    }
}