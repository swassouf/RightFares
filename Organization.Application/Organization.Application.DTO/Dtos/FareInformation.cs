using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.DTO.Dtos
{
   public class FareInformation
    {
       public string Country { get; set; }
       public string State { get; set; }
       public string City { get; set; }
       public decimal BaseFare { get; set; }
       public decimal PerMile { get; set; }
       public decimal PerMinute { get; set; }
       public string TransportType { get; set; }
       public string TransportOption { get; set; }
    }
}
