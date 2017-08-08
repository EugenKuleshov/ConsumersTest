using AutoMapper;

namespace ConsumersTest.Services.Services.Base
{
    internal class AbstractService
    {
        protected IMapper Mapper;

        protected AbstractService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
