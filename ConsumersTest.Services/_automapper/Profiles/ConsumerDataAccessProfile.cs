using AutoMapper;
using ConsumersTest.DataAccess.Entities;
using ConsumersTest.Services.DTO;

namespace ConsumersTest.Services._automapper.Profiles
{
    internal class ConsumerDataAccessProfile : Profile
    {
        public ConsumerDataAccessProfile()
        {
            CreateMap<Consumer, ConsumerDTO>()
                .ForMember(dest => dest.FullName, opt => opt.ResolveUsing(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<ConsumerDTO, Consumer>();
        }
    }
}
