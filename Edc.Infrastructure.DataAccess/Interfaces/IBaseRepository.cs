﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Edc.Infrastructure.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(object id);

        TEntity Insert(TEntity entity);
        IEnumerable<TEntity> BulkInsert(IEnumerable<TEntity> entities);
        void BulkUpdate(IEnumerable<TEntity> entities);
        void BulkDelete(IEnumerable<TEntity> entities);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}
