using ConsumersTest.Wcf.Contracts.Data;
using System.Collections.Generic;
using System.ServiceModel;

namespace ConsumersTest.Wcf.Contracts.Services
{
    [ServiceContract]
    interface IConsumerWcfService
    {
        [OperationContract]
        List<Consumer> GetAll();

        [OperationContract]
        Consumer Get(int consumerId);

        [OperationContract]
        void Delete(int consumerId);

        [OperationContract]
        void Add(Consumer consumer);
    }
}
