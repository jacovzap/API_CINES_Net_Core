using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPICine.Data;
using webAPICine.Data.Entities;
using webAPICine.Models;

namespace webAPICine.Data
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<CineEntity, CineModel>()
                .ReverseMap();


            this.CreateMap<MovieModel, MovieEntity>()
                .ForMember(des => des.Cine, opt => opt.MapFrom(scr => new CineEntity { id = scr.CineId }))
                .ReverseMap()
                .ForMember(dest => dest.CineId, opt => opt.MapFrom(scr => scr.Cine.id));
            //this.CreateMap<Camp, CampModel>()
            //  .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName))
            //  .ReverseMap();

            //this.CreateMap<Talk, TalkModel>()
            //  .ReverseMap()
            //  .ForMember(t => t.Camp, opt => opt.Ignore())
            //  .ForMember(t => t.Speaker, opt => opt.Ignore());
        }
    }
}
