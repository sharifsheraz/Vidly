using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;
using Vidly.Repositories;
using Vidly.Repositories.Core;

namespace Vidly.Repositories.Persistent
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<MovieDto> GetMoviesWithQuery(string query = null)
        {
            var MoviesQuery = VidlyContext.Movies.Include(c => c.Genre);
            if (!String.IsNullOrWhiteSpace(query))
                MoviesQuery = MoviesQuery.Where(c => c.Name.Contains(query));
            var MovieDtos = MoviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return MovieDtos;

        }
        public MovieDto GetMovieWithId(int id)
        {
            var Movie = VidlyContext.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (Movie == null)
                return null;
            return Mapper.Map<Movie, MovieDto>(Movie);
        }
        public int CreateMovie(MovieDto MovieDto)
        {
            var Movie = Mapper.Map<MovieDto, Movie>(MovieDto);
            VidlyContext.Movies.Add(Movie);
            //VidlyContext.SaveChanges();
            MovieDto.Id = Movie.Id;
            return Movie.Id;
        }
        public void UpdateMovie(int id, MovieDto MovieDto)
        {
            var MovieInDb = VidlyContext.Movies.SingleOrDefault(c => c.Id == id);
            if (MovieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<MovieDto, Movie>(MovieDto, MovieInDb);
            MovieInDb.Id = id;
            //VidlyContext.SaveChanges();
        }
        public void DeleteMovie(int id)
        {
            var MovieInDb = VidlyContext.Movies.SingleOrDefault(c => c.Id == id);
            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            VidlyContext.Movies.Remove(MovieInDb);
            //VidlyContext.SaveChanges();

        }
        public ApplicationDbContext VidlyContext
        {
            get { return Context as ApplicationDbContext; }
        }

    }
}