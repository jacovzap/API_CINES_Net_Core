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
    [Route("api/[controller]")]
    public class CinesController : ControllerBase
    {
        private ICinesService _cinesService;

        public CinesController(ICinesService cinesService)
        {
            _cinesService = cinesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CineModel>>> GetCines(string orderBy = "id")
        {
            try
            {
                return Ok(await _cinesService.GetCinesAsync(orderBy, false));
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

        [HttpDelete("{cineId:int}")]
        public async Task<ActionResult<DeleteModel>> DeleteCine(int cineId)
        {
            try
            {
                return Ok(await _cinesService.DeleteCineAsync(cineId));
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

        [HttpGet("{cineId:int}", Name = "GetCine")]
        public async Task<ActionResult<CineModel>> GetCine(int cineId)
        {
            try
            {
                return Ok(await _cinesService.GetCineAsync(cineId, false));
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
        public async Task<ActionResult<CineModel>> CreateCine([FromBody] CineModel cine)
        {
            try
            {
                var cineCreated = await _cinesService.CreateCineAsync(cine);
                return CreatedAtRoute("GetCine", new { cineId = cine.id }, cineCreated);
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

        [HttpPut("{cineId:int}")]
        public async Task<ActionResult<CineModel>> UpdateCine(int cineId, [FromBody] CineModel cine)
         {
            try
            {
                return Ok(await _cinesService.UpdateCineAsync(cineId, cine));
            }
            catch(NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, $"Somethin happened: { ex.Message}");
            }
         }

    }
}
