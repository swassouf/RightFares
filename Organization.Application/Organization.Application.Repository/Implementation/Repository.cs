using Organization.Application.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Organization.Application.Repository.Context;
using Organization.Application.DTO.Interface;

namespace Organization.Application.Repository.Implementation
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class, IEntity
    {

        public IList<Entity> GetAll(params Expression<Func<Entity, Object>>[] includeProperties)
        {
            using (var ctx = new DispatchContext())
            {

                var query = ctx.Set<Entity>().AsQueryable<Entity>();
                query = includeProperties.Aggregate(query, (x, y) => x.Include(y));
                return query.ToList();
            }
        }

        public Entity GetById(int id)
        {
            using (var ctx = new DispatchContext())
            {

                return ctx.Set<Entity>().Where(x => x.ID == id).FirstOrDefault();
            }
        }


        public Entity GetById(int id, params Expression<Func<Entity, Object>>[] includeProperties)
        {

            using (var ctx = new DispatchContext())
            {

                var query = ctx.Set<Entity>().AsQueryable<Entity>();
                query = includeProperties.Aggregate(query, (x, y) => x.Include(y));

                return query.FirstOrDefault(x => x.ID == id);


            }
        }

        public Task<Entity> GetByIdAsync(int id, params Expression<Func<Entity, Object>>[] includeProperties)
        {

            using (var ctx = new DispatchContext())
            {

                var query = ctx.Set<Entity>().AsQueryable<Entity>();
                query = includeProperties.Aggregate(query, (x, y) => x.Include(y));

                return Task.FromResult(query.FirstOrDefault(x => x.ID == id));


            }
        }

        public IList<Entity> GetWhere(Expression<Func<Entity, bool>> predicate)
        {

            using (var ctx = new DispatchContext())
            {

                return ctx.Set<Entity>().Where(predicate).ToList();
            }
        }

        public Entity CreateEntity(Entity entity)
        {
            using (var ctx = new DispatchContext())
            {

                var addedEntity = ctx.Set<Entity>().Add(entity);
                ctx.SaveChanges();
                return addedEntity;

            }
        }

        public async Task<Entity> UpdateAsync(Entity entity)
        {
            using (var ctx = new DispatchContext())
            {
                var existing = ctx.Set<Entity>().Find(entity.ID);

                ctx.Entry(existing).CurrentValues.SetValues(entity);
                await ctx.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<Entity> AddEntityAsync(Entity entity)
        {
            using (var ctx = new DispatchContext())
            {
                ctx.Set<Entity>().Add(entity);
                await ctx.SaveChangesAsync();
                return entity;
            }
        }

    }
}
