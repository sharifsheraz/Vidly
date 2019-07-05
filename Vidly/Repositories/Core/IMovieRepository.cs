using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Repositories.Core
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<MovieDto> GetMoviesWithQuery(string query = null);
        MovieDto GetMovieWithId(int id);
        int CreateMovie(MovieDto MovieDto);
        void UpdateMovie(int id, MovieDto MovieDto);
        void DeleteMovie(int id);
    }
}
