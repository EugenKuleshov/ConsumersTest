using ConsumersTest.DataAccess.Repositories.Interfaces;
using System;
using System.Data;

namespace ConsumersTest.DataAccess.Infrastructure.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IDbTransaction Transaction { get; }

        T ResolveRepository<T>() where T: IRepository;

        void SaveChanges();
    }
}
