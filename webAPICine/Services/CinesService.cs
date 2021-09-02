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
    public class CinesService : ICinesService
    {
        ILibraryRepository _libraryRepository;
        private IMapper _mapper;

        private HashSet<string> allowedOrderByParameters = new HashSet<string>()
        {
            "id",
            "name",
            "fundation-date",
            "country"
        };

        public CinesService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<CineModel> CreateCineAsync(CineModel cineModel)
        {
            var cineEntity = _mapper.Map<CineEntity>(cineModel);
            _libraryRepository.CreateCine(cineEntity);
            var result = await _libraryRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<CineModel>(cineEntity);
            }

            throw new Exception("Database Error");
        }

        public async Task<DeleteModel> DeleteCineAsync(int cineId)
        {
            await GetCineAsync(cineId);

            var DeleteResult = await _libraryRepository.DeleteCineAsync(cineId);

            var saveResult = await _libraryRepository.SaveChangesAsync();

            if (!saveResult || !DeleteResult)
            {
                throw new Exception("Database Error");
            }


            if (saveResult)
            {
                return new DeleteModel()
                {
                    IsSuccess = saveResult,
                    Message = "The cine was deleted."
                };
            }
            else
            {
                return new DeleteModel()
                {
                    IsSuccess = saveResult,
                    Message = "The cine was not deleted."
                };
            }
        }

        public async Task<IEnumerable<CineModel>> GetCinesAsync(string orderBy, bool showMovies)
        {
            if (!allowedOrderByParameters.Contains(orderBy.ToLower()))
            {
                throw new BadRequestOperation($"the field: {orderBy} is not supported, please use one of these {string.Join(",", allowedOrderByParameters)}");
            }

            var entityList = await _libraryRepository.GetCinesAsync(orderBy, showMovies);
            var modelList = _mapper.Map<IEnumerable<CineModel>>(entityList);
            return modelList;
        }

        public async Task<CineModel> GetCineAsync(int cineId, bool showMovies = false)
        {
            var cine = await _libraryRepository.GetCineAsync(cineId, showMovies);
            if (cine == null)
            {
                throw new NotFoundOperationException($"The company with id:{cineId} does not exists");
            }

            return _mapper.Map<CineModel>(cine);
        }

        public async Task<CineModel> UpdateCineAsync(int cineId, CineModel cineModel)
        {
            var cineEntity = _mapper.Map<CineEntity>(cineModel);
            await GetCineAsync(cineId);
            cineEntity.id = cineId;
            _libraryRepository.UpdateCine(cineEntity);

            var saveResult = await _libraryRepository.SaveChangesAsync();

            if (!saveResult)
            {
                throw new Exception("Database Error");
            }
            return cineModel;
        }
    }
}
