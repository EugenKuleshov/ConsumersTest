using ConsumersTest.DataAccess.Entities;
using System.Collections.Generic;

namespace ConsumersTest.DataAccess.Repositories.Interfaces
{
    public interface IConsumerRepository: IRepository
    {
        IList<Consumer> GetAll();

        Consumer Get(int consumerId);

        void Delete(int consumerId);

        void Add(Consumer consumer);
    }
}
