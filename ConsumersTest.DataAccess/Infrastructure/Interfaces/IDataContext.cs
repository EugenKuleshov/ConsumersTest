using System.Data;

namespace ConsumersTest.DataAccess.Infrastructure.Interfaces
{
    public interface IDataContext
    {
        IUnitOfWork CreateUnitOfWork();
        IDbCommand CreateCommand();
    }
}
