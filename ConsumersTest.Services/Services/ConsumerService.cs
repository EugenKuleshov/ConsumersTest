using ConsumersTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using ConsumersTest.Services.DTO;

namespace ConsumersTest.Services.Services
{
    internal class ConsumerService : IConsumerService
    {
        public void Add(ConsumerDTO consumer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int consumerId)
        {
            throw new NotImplementedException();
        }

        public ConsumerDTO Get(int consumerId)
        {
            return new ConsumerDTO() { Email = "test"};
        }

        public List<ConsumerDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
