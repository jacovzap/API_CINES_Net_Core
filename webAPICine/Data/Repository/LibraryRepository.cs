using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using webAPICine.Data.Entities;
using webAPICine.Models;
using VideoGameAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace webAPICine.Data
{
    public class LibraryRepository : ILibraryRepository
    {
        private LibraryDbContext _dbContext;

        public LibraryRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*private List<CineEntity> cines = new List<CineEntity>()
        {
            new CineEntity(){id = 1, name = "CINE CENTER", location = "SANTA CRUZ"},
            new CineEntity(){id = 2, name = "PRIME CINEMAS", location = "COCHABAMBA"},
            new CineEntity(){id = 3, name = "CINE NORTE", location = "COCHABAMBA"},
            new CineEntity(){id = 4, name = "CINE CAPITOL", location = "COCHABAMBA"}

        };

        private List<MovieEntity> moviesCineCenter = new List<MovieEntity>()
        {
            new MovieEntity(){id = 1, name = "JOKER", imageLink = "https://fotos.subefotos.com/b03ee18452432ba0c37c2cae03bd2311o.jpg", cineId = 1},
            new MovieEntity(){id = 8, name = "CAPITANA MARVEL", imageLink = "https://fotos.subefotos.com/c08db193361cf8002215cdd9b1525e60o.jpg", cineId = 1},
            new MovieEntity(){id = 3, name = "AVENGERS: ENDGAME", imageLink = "https://fotos.subefotos.com/7042a050cc01c4e289d69b6388415086o.jpg", cineId = 1},
            new MovieEntity(){id = 5, name = "1917", imageLink = "https://fotos.subefotos.com/a9da4abd15d864b27189d1594f8e1b51o.jpg", cineId = 1},
            new MovieEntity(){id = 4, name = "JOJO RABBIT", imageLink = "https://fotos.subefotos.com/203cf588c6f77e4d1066d10e368cec8fo.jpg", cineId = 1},
            new MovieEntity(){id = 7, name = "TOY STORY 4", imageLink = "https://fotos.subefotos.com/c22bfda250cfc443570bbb427e04d234o.jpg", cineId = 1},
            new MovieEntity(){id = 6, name = "ALADIN", imageLink = "https://fotos.subefotos.com/4ceb050bfe9e14efae9ab537139713d4o.jpg", cineId = 1},
            new MovieEntity(){id = 2, name = "PROYECTO GEMINIS", imageLink = "https://fotos.subefotos.com/caf3df0dd6a2f64007e522c8fbfe5c5fo.jpg", cineId = 1}
        };

        private List<MovieEntity> moviesPrimeCinemas = new List<MovieEntity>()
        {   
            new MovieEntity(){id = 3, name = "JOKER", imageLink = "https://fotos.subefotos.com/b03ee18452432ba0c37c2cae03bd2311o.jpg", cineId = 2},
            new MovieEntity(){id = 2, name = "CAPITANA MARVEL", imageLink = "https://fotos.subefotos.com/c08db193361cf8002215cdd9b1525e60o.jpg", cineId = 2},
            new MovieEntity(){id = 5, name = "AVENGERS: ENDGAME", imageLink = "https://fotos.subefotos.com/7042a050cc01c4e289d69b6388415086o.jpg", cineId = 2},
            new MovieEntity(){id = 8, name = "1917", imageLink = "https://fotos.subefotos.com/a9da4abd15d864b27189d1594f8e1b51o.jpg", cineId = 2},
            new MovieEntity(){id = 1, name = "JOJO RABBIT", imageLink = "https://fotos.subefotos.com/203cf588c6f77e4d1066d10e368cec8fo.jpg", cineId = 2},
            new MovieEntity(){id = 6, name = "TOY STORY 4", imageLink = "https://fotos.subefotos.com/c22bfda250cfc443570bbb427e04d234o.jpg", cineId = 2},
            new MovieEntity(){id = 7, name = "ALADIN", imageLink = "https://fotos.subefotos.com/4ceb050bfe9e14efae9ab537139713d4o.jpg", cineId = 2},
            new MovieEntity(){id = 4, name = "US", imageLink = "https://fotos.subefotos.com/b54436b5c89339c6bfef08fd979b631fo.jpg", cineId = 2}
        };

        private List<MovieEntity> moviesCineNorte = new List<MovieEntity>()
        {
            new MovieEntity(){id = 8, name = "JOKER", imageLink = "https://fotos.subefotos.com/b03ee18452432ba0c37c2cae03bd2311o.jpg", cineId = 3},
            new MovieEntity(){id = 7, name = "CAPITANA MARVEL", imageLink = "https://fotos.subefotos.com/c08db193361cf8002215cdd9b1525e60o.jpg", cineId = 3},
            new MovieEntity(){id = 6, name = "AVENGERS: ENDGAME", imageLink = "https://fotos.subefotos.com/7042a050cc01c4e289d69b6388415086o.jpg", cineId = 3},
            new MovieEntity(){id = 5, name = "1917", imageLink = "https://fotos.subefotos.com/a9da4abd15d864b27189d1594f8e1b51o.jpg", cineId = 3},
            new MovieEntity(){id = 4, name = "JOJO RABBIT", imageLink = "https://fotos.subefotos.com/203cf588c6f77e4d1066d10e368cec8fo.jpg", cineId = 3},
            new MovieEntity(){id = 3, name = "TOY STORY 4", imageLink = "https://fotos.subefotos.com/c22bfda250cfc443570bbb427e04d234o.jpg", cineId = 3},
            new MovieEntity(){id = 2, name = "ALADIN", imageLink = "https://fotos.subefotos.com/4ceb050bfe9e14efae9ab537139713d4o.jpg", cineId = 3},
            new MovieEntity(){id = 1, name = "MIDSOMAR", imageLink = "https://fotos.subefotos.com/dd6777fd465472cd2b475f45548f068bo.jpg", cineId = 3}
        };

        private List<MovieEntity> moviesCineCapitol = new List<MovieEntity>()
        {
            new MovieEntity(){id = 2, name = "JOKER", imageLink = "https://fotos.subefotos.com/b03ee18452432ba0c37c2cae03bd2311o.jpg", cineId = 4},
            new MovieEntity(){id = 4, name = "CAPITANA MARVEL", imageLink = "https://fotos.subefotos.com/c08db193361cf8002215cdd9b1525e60o.jpg", cineId = 4},
            new MovieEntity(){id = 1, name = "AVENGERS: ENDGAME", imageLink = "https://fotos.subefotos.com/7042a050cc01c4e289d69b6388415086o.jpg", cineId = 4},
            new MovieEntity(){id = 6, name = "1917", imageLink = "https://fotos.subefotos.com/a9da4abd15d864b27189d1594f8e1b51o.jpg", cineId = 4},
            new MovieEntity(){id = 8, name = "JOJO RABBIT", imageLink = "https://fotos.subefotos.com/203cf588c6f77e4d1066d10e368cec8fo.jpg", cineId = 4},
            new MovieEntity(){id = 7, name = "TOY STORY 4", imageLink = "https://fotos.subefotos.com/c22bfda250cfc443570bbb427e04d234o.jpg", cineId = 4},
            new MovieEntity(){id = 5, name = "ALADIN", imageLink = "https://fotos.subefotos.com/4ceb050bfe9e14efae9ab537139713d4o.jpg", cineId = 4},
            new MovieEntity(){id = 3, name = "ONCE UPON A TIME IN HOLLYWOOD", imageLink = "https://fotos.subefotos.com/98ce6a9f087c11ab1b46e9568710ce5eo.jpg", cineId = 4},
        };
        
        */

  
        public void CreateCine(CineEntity company)
        {
            _dbContext.Cines.Add(company);
        }

        public async Task<bool> DeleteCineAsync(int cineId)
        {

            var cineToDelete = await _dbContext.Cines.FirstOrDefaultAsync(c => c.id == cineId);
            _dbContext.Cines.Remove(cineToDelete);

            /*var companyToDelete = new CompanyEntity() { Id = companyId };
            _dbContext.Companies.Attach(companyToDelete);
            _dbContext.Entry(companyToDelete).State = EntityState.Deleted;*/

            return true;
        }

        public async Task<IEnumerable<CineEntity>> GetCinesAsync(string orderBy, bool showMovies = false)
        {
            IQueryable<CineEntity> query = _dbContext.Cines;
            query = query.AsNoTracking();

            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(c => c.id);
                    break;
                case "name":
                    query = query.OrderBy(c => c.name);
                    break;
                case "fundation-date":
                    query = query.OrderBy(c => c.location);
                    break;   
                default:
                    query = query.OrderBy(c => c.id); ;
                    break;
            }
            return await query.ToListAsync();
        }

        public async Task<CineEntity> GetCineAsync(int cineId, bool showMovies = false)
        {
            IQueryable<CineEntity> query = _dbContext.Cines;
            query = query.AsNoTracking();

            if (showMovies)
            {
                query = query.Include(c => c.Movies);
            }

            //tolist()
            //toArray()
            //foreach
            //firstOfDefaul
            //Single
            //Count

            return await query.FirstOrDefaultAsync(c => c.id == cineId);
        }

        public bool UpdateCine(CineEntity cineModel)
        {
            var cineToUpdate = _dbContext.Cines.FirstOrDefault(c => c.id == cineModel.id);

            _dbContext.Entry(cineToUpdate).CurrentValues.SetValues(cineModel);

            /*if (companyModel.Name != null)
            {
                _dbContext.Entry(companyModel).Property(p => p.Name).IsModified = true;
            }*/

            /*companyToUpdate.CEO = companyModel.CEO ?? companyToUpdate.CEO;
            companyToUpdate.Country = companyModel.Country ?? companyToUpdate.Country;
            companyToUpdate.FundationDate = companyModel.FundationDate ?? companyToUpdate.FundationDate;
            companyToUpdate.Name = companyModel.Name ?? companyToUpdate.Name;*/
            return true;
        }

        public void CreateMovie(MovieEntity movie)
        {
            if (movie.Cine != null)
            {
                _dbContext.Entry(movie.Cine).State = EntityState.Unchanged;
            }
            _dbContext.Movies.Add(movie);
        }

        public async Task<MovieEntity> GetMovieAsync(int cineId)
        {
            IQueryable<MovieEntity> query = _dbContext.Movies;
            query = query.Include(v => v.Cine);
            query = query.AsNoTracking();
            var videogame = await query.SingleOrDefaultAsync(v => v.id == cineId);
            return videogame;
        }

        public async Task<IEnumerable<MovieEntity>> GetMoviesAsync(int cineId)
        {
            IQueryable<MovieEntity> query = _dbContext.Movies;
            query = query.Where(v => v.Cine.id == cineId);
            query = query.Include(v => v.Cine);
            query = query.AsNoTracking();

            return await query.ToArrayAsync(); ;
        }

        public async Task<bool> UpdateMovieAsync(MovieEntity movie)
        {
            var movieToUpdate = await _dbContext.Movies.FirstOrDefaultAsync(v => v.id == movie.id);
            movieToUpdate.name = movie.name ?? movieToUpdate.name;
            movieToUpdate.imageLink = movie.imageLink ?? movieToUpdate.imageLink;
            movieToUpdate.valoracion = movie.valoracion;
            movieToUpdate.director = movie.director ?? movieToUpdate.director;
            movieToUpdate.descripcion = movie.descripcion ?? movieToUpdate.descripcion;
            movieToUpdate.genero = movie.genero ?? movieToUpdate.genero;

            return true;
        }

        public bool DeleteMovie(int movieId)
        {
            var videogameToDelete = new MovieEntity() { id = movieId };
            _dbContext.Entry(videogameToDelete).State = EntityState.Deleted;
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}

