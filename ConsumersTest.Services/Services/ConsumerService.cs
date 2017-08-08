using System.Collections.Generic;
using ConsumersTest.Services.DTO;
using ConsumersTest.Services.Services.Base;
using AutoMapper;
using ConsumersTest.Services.Interfaces;

using IConsumerWcfService = ConsumersTest.Wcf.ConsumerServiceReference.IConsumerService;
using Consumer = ConsumersTest.Wcf.ConsumerServiceReference.Consumer;

namespace ConsumersTest.Services.Services
{
    internal class ConsumerService : AbstractService, IConsumerService
    {
        private IConsumerWcfService _consumerWcfService;
        
        public ConsumerService(IMapper mapper, IConsumerWcfService consumerWcfService) : base(mapper)
        {
            _consumerWcfService = consumerWcfService;
        }

        public void Add(ConsumerDTO consumerDTO)
        {
            var consumer = Mapper.Map<Consumer>(consumerDTO);
            _consumerWcfService.Add(consumer);
        }

        public void Delete(int consumerId)
        {
            _consumerWcfService.Delete(consumerId);
        }

        public ConsumerDTO Get(int consumerId)
        {
            var consumer = _consumerWcfService.Get(consumerId);
            var consumerDTO = Mapper.Map<ConsumerDTO>(consumer);
            return consumerDTO;
        }

        public IList<ConsumerDTO> GetAll()
        {
            var consumers = _consumerWcfService.GetAll();
            var consumersDTO = Mapper.Map<IList<ConsumerDTO>>(consumers);
            return consumersDTO;
        }
    }
}
