using Organization.Application.Business.Interface;
using Organization.Application.DTO.Interface;
using Organization.Application.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Business.Implementation
{
    public class CommonBL<Entity> : ICommonBL<Entity> where Entity : class, IEntity
    {
        IRepository<Entity> _Repository;
        public CommonBL(IRepository<Entity> repository)
        {
            this._Repository = repository;
        }

        public async Task<Entity> AddEntityAsync(Entity entity)
        {
            await this._Repository.AddEntityAsync(entity);

            return entity;
        }

        public IList<Entity> GetALL(params Expression<Func<Entity, Object>>[] includeProperties)
        {
            return this._Repository.GetAll();
        }
    }
}
