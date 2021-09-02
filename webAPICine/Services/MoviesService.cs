using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPICine.Models;
using webAPICine.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using webAPICine.Exceptions;
using webAPICine.Data.Entities;

namespace webAPICine.Services
{
    public class MoviesService : IMoviesService
    {

        private IMapper _mapper;
        private ILibraryRepository _libraryRepository;

        public MoviesService(IMapper mapper, ILibraryRepository libraryRepository)
        {
            _mapper = mapper;
            _libraryRepository = libraryRepository;
        }

        public async Task<MovieModel> CreateMovieAsync(int cineId, MovieModel movie)
        {
            await validateCine(cineId);
            var movieEntity = _mapper.Map<MovieEntity>(movie);
            _libraryRepository.CreateMovie(movieEntity);
            var saveResult = await _libraryRepository.SaveChangesAsync();
            if (!saveResult)
            {
                throw new Exception("save error");
            }

            var modelToReturn = _mapper.Map<MovieModel>(movieEntity);
            modelToReturn.CineId = cineId;
            return modelToReturn;
        }

        public async Task<bool> DeleteMovieAsync(int cineId, int movieId)
        {
            await GetMovieAsync(cineId, movieId);
            _libraryRepository.DeleteMovie(movieId);
            var saveRestul = await _libraryRepository.SaveChangesAsync();
            if (!saveRestul)
            {
                throw new Exception("Error while saving.");
            }
            return true;
        }

        public async Task<MovieModel> GetMovieAsync(int cineId, int movieId)
        {
            await validateCine(cineId);
            await validateMovie(movieId);
            var videogame = await _libraryRepository.GetMovieAsync(movieId);
            if (videogame.Cine.id != cineId)
            {
                throw new NotFoundOperationException($"the movie id:{movieId} does not exists for cine id:{cineId}");
            }
            return _mapper.Map<MovieModel>(videogame);
        }

        public async Task<IEnumerable<MovieModel>> GetMoviesAsync(int cineId)
        {
            await validateCine(cineId);
            var videogames = await _libraryRepository.GetMoviesAsync(cineId);
            return _mapper.Map<IEnumerable<MovieModel>>(videogames);
        }

        public async Task<bool> UpdateMovieAsync(int cineId, int movieId, MovieModel movie)
        {
            await GetMovieAsync(cineId, movieId);
            movie.id = movieId;
            await _libraryRepository.UpdateMovieAsync(_mapper.Map<MovieEntity>(movie));
            var saveRestul = await _libraryRepository.SaveChangesAsync();
            if (!saveRestul)
            {
                throw new Exception("Error while saving.");
            }
            return true;
        }

        private async Task validateCine(int cineId)
        {
            var company = await _libraryRepository.GetCineAsync(cineId); //_libraryRepository.GetCompany(companyId);
            if (company == null)
            {
                throw new NotFoundOperationException($"the cine id:{cineId}, does not exist");
            }
        }

        private async Task validateMovie(int movieId)
        {
            var videogame = await _libraryRepository.GetMovieAsync(movieId);
            if (videogame == null)
            {
                throw new NotFoundOperationException($"the movie id:{movieId}, does not exist");
            }
        }
    }
}
