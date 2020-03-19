using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.DTO.Dtos
{
   public class RegistrationResult
    {
        public bool IsExists { get; set; }
        public int MobileConfirmationNumber { get; set; }
        
    }
}
