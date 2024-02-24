using AutoMapper;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<App, AppDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<CarDetails,CarDetailsDTO>();
            CreateMap<UserProfile,UserProfileDTO>();
        }
    }
}
