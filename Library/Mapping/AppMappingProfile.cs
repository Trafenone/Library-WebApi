using AutoMapper;
using Library.Data;
using Library.Models.DTO;

namespace Library.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();

            CreateMap<Book, BookOrdered>()
                .ForMember(dest => dest.Rating,
                    opt => opt.MapFrom(src =>
                    (src.Ratings!.Count > 0) ? src.Ratings.Average(x => x.Score) : 0))
                .ForMember(dest => dest.ReviewsNumber,
                    opt => opt.MapFrom(src => src.Reviews!.Count));
            CreateMap<Book, BookDetail>()
                .ForMember(dest => dest.Rating,
                    opt => opt.MapFrom(src =>
                    (src.Ratings!.Count > 0) ? src.Ratings.Average(x => x.Score) : 0))
                .ForMember(dest => dest.Reviews,
                    opt => opt.MapFrom(src => src.Reviews));

        }
    }
}
