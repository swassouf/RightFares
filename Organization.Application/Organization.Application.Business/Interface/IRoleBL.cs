using Organization.Application.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Business.Interface
{
    public interface IRoleBL
    {
        Task<Role> FindRoleByNameAsync(string roleName);
        Task<IList<PersonRole>> GetRolesAsync(int personId);
    }
}
