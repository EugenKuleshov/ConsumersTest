using ConsumersTest.Wcf.Contracts.Data;
using ConsumersTest.Wcf.Contracts.Services;
using System.Collections.Generic;
using System.ServiceModel;

namespace ConsumersTest.Wcf.Proxies
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
