using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<DTO.Entities.Role> FindRoleByNameAsync(string roleName);
        Task<IList<DTO.Entities.PersonRole>> GetRolesAsync(int personId);
    }
}
