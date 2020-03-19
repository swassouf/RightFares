using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Broker.Models
{
    public class HomeViewModel
    {
        public int CountryId { get; set; } = 238;
        public int StateId { get; set; } = 14;
        public int CityId { get; set; } = 1;
        public RegisterViewModel RegistorModel { get ; set; }
        public IList<DTO.Dtos.FareInformation> FareInformationModel { get; set; }
    }
}
