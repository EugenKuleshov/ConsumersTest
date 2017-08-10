using Autofac;
using ConsumersTest.DataAccess.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumersTest.DataAccess.Infrastructure
{
    internal class AdoNetContext: IDataContext
    {
        private readonly IDbConnection _connection;

        private readonly IConnectionFactory _connectionFactory;

        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        private readonly LinkedList<AdoNetUnitOfWork> _uows = new LinkedList<AdoNetUnitOfWork>();

        private readonly ILifetimeScope _lifetimeScope;

        public AdoNetContext(IConnectionFactory connectionFactory, ILifetimeScope lifetimeScope)
        {
            _connectionFactory = connectionFactory;
            _lifetimeScope = lifetimeScope;
            _connection = _connectionFactory.Create();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            var transaction = _connection.BeginTransaction();
            var uow = new AdoNetUnitOfWork(transaction, RemoveTransaction, RemoveTransaction, _lifetimeScope);
            _rwLock.EnterWriteLock();
            _uows.AddLast(uow);
            _rwLock.ExitWriteLock();
            return uow;
        }

        public IDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand();
            _rwLock.EnterReadLock();
            if (_uows.Count > 0)
                cmd.Transaction = _uows.First.Value.Transaction;
            _rwLock.ExitReadLock();
            return cmd;
        }

        private void RemoveTransaction(AdoNetUnitOfWork obj)
        {
            _rwLock.EnterWriteLock();
            _uows.Remove(obj);
            _rwLock.ExitWriteLock();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
