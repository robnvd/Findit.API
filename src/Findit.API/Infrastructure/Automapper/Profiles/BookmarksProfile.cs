using AutoMapper;
using Findit.DL.Entities;
using Findit.DTO;

namespace Findit.API.Infrastructure.Automapper.Profiles
{
    public class BookmarksProfile : Profile
    {
        public BookmarksProfile()
        {
            CreateMap<Bookmark, BookmarkDto>()
                .ForMember(dest => dest.PlaceId, a => a.MapFrom(src => src.Place.Id));
            CreateMap<BookmarkDto, Bookmark>();
        }
    }
}