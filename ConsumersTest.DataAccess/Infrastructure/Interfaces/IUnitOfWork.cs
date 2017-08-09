using System.Data;

namespace ConsumersTest.DataAccess.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IDbTransaction Transaction { get; }

        void SaveChanges();
        void Dispose();
    }
}
