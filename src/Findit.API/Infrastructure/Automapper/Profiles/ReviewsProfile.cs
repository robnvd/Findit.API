using AutoMapper;
using Findit.DL.Entities;
using Findit.DTO;

namespace Findit.API.Infrastructure.Automapper.Profiles
{
    public class ReviewsProfile : Profile
    {
        public ReviewsProfile()
        {
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
        }
    }
}