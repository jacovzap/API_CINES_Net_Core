using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPICine.Data.Entities;
using webAPICine.Models;

namespace webAPICine.Data
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<CineEntity>> GetCinesAsync(string orderBy, bool showMovies = false);
        Task<CineEntity> GetCineAsync(int cineId, bool showMovies = false);
        void CreateCine(CineEntity cineModel);
        Task<bool> DeleteCineAsync(int cineId);
        bool UpdateCine(CineEntity cineModel);

        //videogames 
        void CreateMovie(MovieEntity movie);
        Task<MovieEntity> GetMovieAsync(int videogameId);
        Task<IEnumerable<MovieEntity>> GetMoviesAsync(int cineId);
        Task<bool> UpdateMovieAsync(MovieEntity movie);
        bool DeleteMovie(int movieId);

        //save changes
        Task<bool> SaveChangesAsync();
    }
}
