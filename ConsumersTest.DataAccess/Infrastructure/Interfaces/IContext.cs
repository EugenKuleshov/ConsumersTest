using System.Data;

namespace ConsumersTest.DataAccess.Infrastructure.Interfaces
{
    public interface IContext
    {
        IUnitOfWork CreateUnitOfWork();
        IDbCommand CreateCommand();
    }
}
