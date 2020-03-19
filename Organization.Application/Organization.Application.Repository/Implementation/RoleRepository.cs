using Organization.Application.DTO.Entities;
using Organization.Application.Repository.Context;
using Organization.Application.Repository.Interface;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Repository.Implementation
{
    public class RoleRepository : Repository<DTO.Entities.Role>, IRoleRepository
    {

        public async Task<Role> FindRoleByNameAsync(string roleName)
        {
            using (var ctx = new DispatchContext())
            {
                var role = await ctx.Roles.Where(r => r.Name == roleName).FirstOrDefaultAsync();

                return role;
            }
        }

        public async Task<IList<PersonRole>> GetRolesAsync(int personId)
        {
            using (var ctx = new DispatchContext())
            {
                return await ctx.PersonRoles.Include("Role").Where(p => p.PersonId == personId).ToListAsync();
            }
        }
    }
}
