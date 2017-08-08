using ConsumersTest.Services.Wcf.Contracts.Services;
using System.Collections.Generic;
using System.ServiceModel;
using ConsumersTest.Services.Wcf.Contracts.Data;

namespace ConsumersTest.Services.Wcf.Proxies
{
    internal class ConsumerWcfClient : ClientBase<IConsumerWcfService>, IConsumerWcfService
    {
        public ConsumerWcfClient(string endpoint) : base(endpoint)
        {
        }

        public void Add(Consumer consumer)
        {
            Channel.Add(consumer);
        }

        public void Delete(int consumerId)
        {
            Channel.Delete(consumerId);
        }

        public Consumer Get(int consumerId)
        {
            return Channel.Get(consumerId);
        }

        public List<Consumer> GetAll()
        {
            return Channel.GetAll();
        }
    }
}
