using AutoMapper;
using Findit.DL.Entities;
using Findit.DTO;

namespace Findit.API.Infrastructure.Automapper.Profiles
{
    public class PlacesProfile : Profile
    {
        public PlacesProfile()
        {
            CreateMap<Place, PlaceDto>();
            CreateMap<PlaceDto, Place>();
        }   
    }
}