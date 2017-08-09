using System.Data;

namespace ConsumersTest.DataAccess.Infrastructure.Interfaces
{
    internal interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
