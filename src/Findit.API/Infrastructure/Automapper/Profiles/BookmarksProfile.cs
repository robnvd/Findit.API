using AutoMapper;
using Findit.DL.Entities;
using Findit.DTO;

namespace Findit.API.Infrastructure.Automapper.Profiles
{
    public class BookmarksProfile : Profile
    {
        public BookmarksProfile()
        {
            CreateMap<Bookmark, BookmarkDto>();
            CreateMap<BookmarkDto, Bookmark>();
        }
    }
}