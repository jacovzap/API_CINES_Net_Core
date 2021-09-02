using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using webAPICine.Exceptions;
using webAPICine.Models;
using webAPICine.Services;

namespace webAPICine.Controllers
{
    [Route("api/cines/{cineId:int}/[controller]")]
    public class MoviesController : ControllerBase
    {
        private IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetMovies(int cineId)
        {
            try
            {
                return Ok(await _moviesService.GetMoviesAsync(cineId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happened: {ex.Message}");
            }
        }


        [HttpGet("{movieId:int}")]
        public async Task<ActionResult<MovieModel>> GetMovie(int cineId, int movieId)
        {
            try
            {
                return Ok(await _moviesService.GetMovieAsync(cineId, movieId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }


      

        [HttpPost]
        public async Task<ActionResult<CineModel>> CreateMovie(int cineId, [FromBody] MovieModel movie)
        {
            try
            {
                var movieCreated = await _moviesService.CreateMovieAsync(cineId, movie);
                return CreatedAtRoute("GetMovie", new { cineId = cineId, movieId = movieCreated.id }, movieCreated);
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpDelete("{movieId:int}")]
        public async Task<ActionResult<DeleteModel>> DeleteMovie(int cineId, int movieId)
        {
            try
            {
                return Ok(await _moviesService.DeleteMovieAsync(cineId, movieId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happened: {ex.Message}");
            }
        }


        [HttpPut("{movieId:int}")]
        public async Task<ActionResult<CineModel>> UpdateMovie(int cineId, int movieId, [FromBody] MovieModel movie)
        {
            try
            {
                return Ok(await _moviesService.UpdateMovieAsync(cineId, movieId, movie));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Somethin happened: { ex.Message}");
            }
        }

    }
}
