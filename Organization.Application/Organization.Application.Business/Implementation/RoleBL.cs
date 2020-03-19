using Organization.Application.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization.Application.DTO.Entities;
using Organization.Application.Repository.Interface;

namespace Organization.Application.Business.Implementation
{
    public class RoleBL : IRoleBL
    {
        IRoleRepository _RoleRepository;

        public RoleBL(IRoleRepository roleRepository)
        {
            this._RoleRepository = roleRepository;
        }

        public async Task<Role> FindRoleByNameAsync(string roleName)
        {
            return await _RoleRepository.FindRoleByNameAsync(roleName);
        }

        public async Task<IList<PersonRole>> GetRolesAsync(int personId)
        {
            return await _RoleRepository.GetRolesAsync(personId);
        }
    }
}
