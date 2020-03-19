using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Business.Interface
{
    public interface ICommonBL<Entity>
    {
        IList<Entity> GetALL(params Expression<Func<Entity, Object>>[] includeProperties);
        Task<Entity> AddEntityAsync(Entity entity);
    }
}
