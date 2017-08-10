using Autofac;
using ConsumersTest.DataAccess.Infrastructure.Interfaces;
using ConsumersTest.DataAccess.Repositories.Interfaces;
using System;
using System.Data;

namespace ConsumersTest.DataAccess.Infrastructure
{
    internal class AdoNetUnitOfWork: IUnitOfWork
    {
        private IDbTransaction _transaction;

        private readonly Action<AdoNetUnitOfWork> _rolledBack;

        private readonly Action<AdoNetUnitOfWork> _committed;

        private readonly ILifetimeScope _lifeTimeScope;

        public AdoNetUnitOfWork(IDbTransaction transaction, Action<AdoNetUnitOfWork> rolledBack, Action<AdoNetUnitOfWork> committed, ILifetimeScope lifetimeScope)
        {
            Transaction = transaction;
            _transaction = transaction;
            _rolledBack = rolledBack;
            _committed = committed;

            _lifeTimeScope = lifetimeScope;
        }

        public IDbTransaction Transaction { get; private set; }

        public T ResolveRepository<T>() where T: IRepository
        {
            return _lifeTimeScope.Resolve<T>();
        }

        public void Dispose()
        {
            if (_transaction == null)
                return;
            _transaction.Rollback();
            _transaction.Dispose();
            _rolledBack(this);
            _transaction = null;
        }        

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("May not call save changes twice.");
            _transaction.Commit();
            _committed(this);
            _transaction = null;
        }
    }
}
