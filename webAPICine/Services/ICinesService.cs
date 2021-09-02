using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPICine.Models;

namespace webAPICine.Services
{
    public interface ICinesService
    {
        Task<IEnumerable<CineModel>> GetCinesAsync(string orderBy, bool showVideogames);
        Task<CineModel> GetCineAsync(int cineId, bool showVideogames);
        Task<CineModel> CreateCineAsync(CineModel cineModel);
        Task<DeleteModel> DeleteCineAsync(int cineId);
        Task<CineModel> UpdateCineAsync(int cineId, CineModel cineModel);

    }
}
