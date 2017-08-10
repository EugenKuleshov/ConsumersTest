using AutoMapper;
using ConsumersTest.Services.DTO;
using ConsumersTest.Wcf.ConsumerServiceReference;

namespace ConsumersTest.Services._automapper.Profiles
{
    internal class ConsumerWcfProfile: Profile
    {
        public ConsumerWcfProfile()
        {
            CreateMap<Consumer, ConsumerDTO>()
                .ForMember(dest => dest.FullName, opt => opt.ResolveUsing(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<ConsumerDTO, Consumer>()
                .ForMember(dest => dest.ExtensionData, opt => opt.Ignore());
        }
    }
}
