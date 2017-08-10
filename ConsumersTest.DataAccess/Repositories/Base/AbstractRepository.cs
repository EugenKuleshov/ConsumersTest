using ConsumersTest.DataAccess.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace ConsumersTest.DataAccess.Repositories.Base
{
    internal abstract class AbstractRepository<TEntity> where TEntity : new()
    {
        public AbstractRepository(IDataContext context)
        {
            Context = context;
        }

        protected IDataContext Context { get; }

        protected IList<TEntity> ToList(IDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (reader.Read())
                {
                    var item = new TEntity();
                    Map(reader, item);
                    items.Add(item);
                }
                return items;
            }
        }
        protected abstract void Map(IDataRecord record, TEntity entity);
    }
}
