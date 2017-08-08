﻿using ConsumersTest.Services.DTO;
using System.Collections.Generic;

namespace ConsumersTest.Services.Interfaces
{
    public interface IConsumerService
    {
        List<ConsumerDTO> GetAll();

        ConsumerDTO Get(int consumerId);

        void Delete(int consumerId);

        void Add(ConsumerDTO consumer);
    }
}
