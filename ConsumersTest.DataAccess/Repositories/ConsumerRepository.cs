using ConsumersTest.DataAccess.Entities;
using ConsumersTest.DataAccess.Repositories.Base;
using ConsumersTest.DataAccess.Repositories.Interfaces;
using System;
using System.Data;
using ConsumersTest.DataAccess.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using ConsumersTest.DataAccess.Infrastructure.Extensions;

namespace ConsumersTest.DataAccess.Repositories
{
    internal class ConsumerRepository : AbstractRepository<Consumer>, IConsumerRepository
    {
        public ConsumerRepository(IDataContext context) : base(context)
        {
        }

        public void Add(Consumer consumer)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO dbo.Consumers (FirstName, LastName, Email, DateOfBirth)
                                            VALUES(@FirstName, @LastName, @Email, @DateOfBirth)";
                command.AddParameter("FirstName", consumer.FirstName);
                command.AddParameter("LastName", consumer.LastName);
                command.AddParameter("Email", consumer.Email);
                command.AddParameter("DateOfBirth", consumer.DateOfBirth);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int consumerId)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"DELETE FROM dbo.Consumers WHERE ConsumerId = @consumerId";
                command.AddParameter("consumerId", consumerId);
                command.ExecuteNonQuery();
            }
        }

        public Consumer Get(int consumerId)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM dbo.Consumers WHERE ConsumerId = @consumerId";
                command.AddParameter("consumerId", consumerId);

                return ToList(command).First();
            }
        }

        public IList<Consumer> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM dbo.Consumers";
                return ToList(command);
            }
        }

        protected override void Map(IDataRecord record, Consumer consumer)
        {
            consumer.ConsumerId = (int)record["ConsumerId"];
            consumer.FirstName = (string)record["FirstName"];
            consumer.LastName = (string)record["LastName"];
            consumer.Email = (string)record["Email"];
            consumer.DateOfBirth = (DateTime)record["DateOfBirth"];
        }
    }
}
