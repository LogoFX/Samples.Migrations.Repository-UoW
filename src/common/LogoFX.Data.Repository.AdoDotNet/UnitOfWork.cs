using System;
using System.Collections;
using System.Data;
using JetBrains.Annotations;
using LogoFX.Data.DbContext.AdoDotNet;

namespace LogoFX.Data.Repository.AdoDotNet
{
    [UsedImplicitly]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private readonly ITransactionFactory _transactionFactory;
        private bool _disposed;
        private Hashtable _repositories;

        private IDbConnection _connection;

        public UnitOfWork(IDbContext dbContext,  ITransactionFactory transactionFactory)
        {
            _dbContext = dbContext;
            _transactionFactory = transactionFactory;
            
            InitializeUnitOfWork();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _connection.Close();
                    _connection.Dispose();
                }                    
            }
                
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            using (var transaction = _transactionFactory.CreateTransaction())
            {
                try
                {
                    _dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {                    
                    transaction.Rollback();
                }                
            }            
        }

        public IRepository<T> Repository<T>()
            where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IRepository<T>) _repositories[type];
            }

            var repositoryType = typeof(Repository<>);

            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

            _repositories.Add(type, repositoryInstance);

            return (IRepository<T>)_repositories[type];
        }

        private void InitializeUnitOfWork()
        {
            _connection = _dbContext.Connection;
            //_connection.Open();
        }

    }
}