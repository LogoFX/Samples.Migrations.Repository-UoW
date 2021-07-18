using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using LogoFX.Data.DbContext.AdoDotNet;

namespace LogoFX.Data.Repository.AdoDotNet
{
    [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
    public class Repository<TEntity> : IRepository<TEntity>, IRepositoryQueryProvider<TEntity>
        where TEntity : class
    {
        private readonly IDbContext _dbContext;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool AddMultiple(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool AddOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool AddOrUpdateMultiple(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMultiple(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Detach(object entity)
        {
            throw new NotImplementedException();
        }

        public void Detach(List<object> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable Find(Expression<Func<TEntity, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public IQueryable Find(Expression<Func<TEntity, bool>> @where, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public TEntity First(Expression<Func<TEntity, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> @where, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            var entities = SetEntities();
            return entities;
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(object id)
        {
            throw new NotImplementedException();
        }

        public RepositoryQuery<TEntity> Query()
        {
            throw new NotImplementedException();
        }

        public void SetIdentityCommand()
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, object>> include)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProperty(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMultiple(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includeProperties = null, int? page = null,
            int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        private IQueryable<TEntity> SetEntities()
        {
            var entities = _dbContext.Set<TEntity>();
            return entities;
        }
    }
}