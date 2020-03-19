using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.DTO.Dtos
{
   public class UserInformation
    {
        //
        // Summary:
        //     Used to record failures for the purposes of lockout
        public virtual int AccessFailedCount { get; set; }
        //
        // Summary:
        //     Email
        public virtual string Email { get; set; }
        //
        // Summary:
        //     User ID (Primary Key)
        public virtual int Id { get; set; }
        //
        // Summary:
        //     Is lockout enabled for this user
        public virtual bool LockoutEnabled { get; set; }
        //
        // Summary:
        //     DateTime in UTC when lockout ends, any time in the past is considered not locked
        //     out.
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        //
        // Summary:
        //     The salted/hashed form of the user password
        public virtual string PasswordHash { get; set; }

        public string MobileCountryCode { get; set; }
        //
        // Summary:
        //     PhoneNumber for the user
        public virtual string PhoneNumber { get; set; }
        //
        // Summary:
        //     Navigation property for user roles
        public virtual IEnumerable<Entities.PersonRole> Roles { get; set; }
    }
}
