using AutoMapper;
using ConsumersTest.Services.DTO;
using ConsumersTest.Wcf.Contracts.Data;

namespace ConsumersTest.Services._automapper.Profiles
{
    internal class ConsumerProfile: Profile
    {
        public ConsumerProfile()
        {
            CreateMap<Consumer, ConsumerDTO>()
                .ForMember(dest => dest.FullName, opt => opt.ResolveUsing(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<ConsumerDTO, Consumer>();
        }
    }
}
