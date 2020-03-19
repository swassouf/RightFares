using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Repository.Interface
{
    public interface IRepository<Entity>
    {
        Entity GetById(int id);
        Entity GetById(int id, params Expression<Func<Entity, Object>>[] includeProperties);
        Task<Entity> GetByIdAsync(int id, params Expression<Func<Entity, Object>>[] includeProperties);
        IList<Entity> GetAll(params Expression<Func<Entity, Object>>[] includeProperties);
        IList<Entity> GetWhere(Expression<Func<Entity, bool>> predicate);

        Entity CreateEntity(Entity entity);

        #region DML
        Task<Entity> UpdateAsync(Entity entity);

        Task<Entity> AddEntityAsync(Entity entity);

        #endregion
    }
}
