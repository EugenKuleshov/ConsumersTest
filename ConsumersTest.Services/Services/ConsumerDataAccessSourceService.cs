using ConsumersTest.Services.Interfaces;
using ConsumersTest.Services.Services.Base;
using System.Collections.Generic;
using AutoMapper;
using ConsumersTest.Services.DTO;
using ConsumersTest.DataAccess.Infrastructure.Interfaces;
using ConsumersTest.DataAccess.Repositories.Interfaces;
using ConsumersTest.DataAccess.Entities;

namespace ConsumersTest.Services.Services
{
    internal class ConsumerDataAccessSourceService : AbstractService, IConsumerService
    {
        private readonly IDataContext _dataContext;

        public ConsumerDataAccessSourceService(IMapper mapper, IDataContext dataContext) : base(mapper)
        {
            _dataContext = dataContext;
        }

        public void Add(ConsumerDTO consumerDTO)
        {
            var consumer = Mapper.Map<Consumer>(consumerDTO);

            using (var unitOfWork = _dataContext.CreateUnitOfWork())
            {
                var repo = unitOfWork.ResolveRepository<IConsumerRepository>();
                repo.Add(consumer);

                unitOfWork.SaveChanges();
            }
        }

        public void Delete(int consumerId)
        {
            using (var unitOfWork = _dataContext.CreateUnitOfWork())
            {
                var repo = unitOfWork.ResolveRepository<IConsumerRepository>();
                repo.Delete(consumerId);

                unitOfWork.SaveChanges();
            }
        }

        public ConsumerDTO Get(int consumerId)
        {
            Consumer consumer;
            using (var unitOfWork = _dataContext.CreateUnitOfWork())
            {
                var repo = unitOfWork.ResolveRepository<IConsumerRepository>();
                consumer = repo.Get(consumerId);
            }

            var consumerDTO = Mapper.Map<ConsumerDTO>(consumer);
            return consumerDTO;
        }

        public IList<ConsumerDTO> GetAll()
        {
            IList<Consumer> consumers;
            using (var unitOfWork = _dataContext.CreateUnitOfWork())
            {
                var repo = unitOfWork.ResolveRepository<IConsumerRepository>();
                consumers = repo.GetAll();
            }

            var consumersDTO = Mapper.Map<IList<ConsumerDTO>>(consumers);
            return consumersDTO;
        }
    }
}
