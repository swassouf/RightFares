using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Broker.Models
{
    public class RoleViewModel
    {
        int RoleId { get; set; }
        public IList<DTO.Entities.Role> UserRoles { get; set; }
        public IList<DTO.Entities.Role> Roles { get; set; } 
    }
}
