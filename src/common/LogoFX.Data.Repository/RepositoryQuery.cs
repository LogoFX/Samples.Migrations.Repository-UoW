using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace LogoFX.Data.Repository
{
    public sealed class RepositoryQuery<TEntity> where TEntity : class
    {
        private readonly List<Expression<Func<TEntity, object>>> 
            _includeProperties;

        private readonly IRepositoryQueryProvider<TEntity> _repository;
        private Expression<Func<TEntity, bool>> _filter;
        private Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> _orderByQueryable;
        private int? _page;
        private int? _pageSize;

        public RepositoryQuery(IRepositoryQueryProvider<TEntity> repository)
        {
            _repository = repository;
            _includeProperties = 
                new List<Expression<Func<TEntity, object>>>();
        }

        public RepositoryQuery<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter)
        {
            _filter = filter;
            return this;
        }

        public RepositoryQuery<TEntity> OrderBy(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            _orderByQueryable = orderBy;
            return this;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public RepositoryQuery<TEntity> Include(
            Expression<Func<TEntity, object>> expression)
        {
            _includeProperties.Add(expression);
            return this;
        }

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public IQueryable<TEntity> GetPage(
            int page, int pageSize, out int totalCount)
        {
            _page = page;
            _pageSize = pageSize;
            totalCount = _repository.Get(_filter).Count();

            return _repository.Get(
                _filter, 
                _orderByQueryable, _includeProperties, _page, _pageSize);
        }

        public IQueryable<TEntity> Get()
        {
            return _repository.Get(
                _filter, 
                _orderByQueryable, _includeProperties, _page, _pageSize);
        }
    }
}