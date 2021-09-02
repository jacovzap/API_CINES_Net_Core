using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPICine.Models;

namespace webAPICine.Services
{
    public interface IMoviesService
    {
        Task<MovieModel> CreateMovieAsync(int cineId, MovieModel movie);
        Task<MovieModel> GetMovieAsync(int cineId, int movieId);
        Task<IEnumerable<MovieModel>> GetMoviesAsync(int cineId);
        Task<bool> UpdateMovieAsync(int cineId, int movieId, MovieModel movie);
        Task<bool> DeleteMovieAsync(int cineId, int movieId);

    }
}
