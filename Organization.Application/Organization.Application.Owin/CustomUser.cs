using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Organization.Application.Owin
{
    public class CustomUser : IUser<string>
    {
        public string Id { get { return this.ID.ToString(); } }

        public string UserName
        {
            get; set;
        }

        public int ID { get; set; } // ID (Primary key)
        public string FirstName { get; set; } // FirstName (length: 100)
        public string MiddleName { get; set; } // MiddleName (length: 100)
        public string LastName { get; set; } // LastName (length: 100)
        public string MobileCountryCode { get; set; } // MobileCountryCode (length: 50)
        public string MobilePhone { get; set; } // MobilePhone (length: 50)
        public string PrimaryEmail { get; set; } // PrimaryEmail (length: 100)
        public System.DateTime? Created { get; set; } // Created
        public string CreatedBy { get; set; } // CreatedBy (length: 100)
        public string Password { get; set; } // Password (length: 1000)
        public bool IsSuspended { get; set; } // IsSuspended
        public bool IsMobileVerified { get; set; } // IsMobileVerified
        public string Ssn { get; set; } // SSN (length: 100)
        public bool IsAcknowledged { get; set; } // IsAcknowledged
        public bool IsOnline { get; set; } // IsOnline
        public bool IsLimoOrTaxiDriver { get; set; } // IsLimoOrTaxiDriver
        public bool EmailConfirmed { get; set; } // EmailConfirmed
        public string SecurityStamp { get; set; } // SecurityStamp
        public bool TwoFactorEnabled { get; set; } // TwoFactorEnabled
        public System.DateTime? LockoutEndDateUtc { get; set; } // LockoutEndDateUtc
        public bool LockoutEnabled { get; set; } // LockoutEnabled
        public int AccessFailedCount { get; set; } // AccessFailedCount
        public virtual ICollection<DTO.Entities.PersonRole> PersonRoles { get; set; }
        public virtual ICollection<DTO.Entities.AspNetUserClaim> Claims { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(CustomUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public static implicit operator CustomUser(DTO.Entities.Person person)
        {
            if (person == null) return null;

            CustomUser user = new CustomUser
            {

                ID = person.ID,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName, // MiddleName (length: 100)
                LastName = person.LastName, // LastName (length: 100)
                MobileCountryCode = person.MobileCountryCode, // MobileCountryCode (length: 50)
                MobilePhone = person.MobilePhone, // MobilePhone (length: 50)
                PrimaryEmail = person.PrimaryEmail, // PrimaryEmail (length: 100)
                Created = person.Created, // Created
                CreatedBy = person.CreatedBy, // CreatedBy (length: 100)
                Password = person.Password, // Password (length: 1000)
                IsSuspended = person.IsSuspended, // IsSuspended
                IsMobileVerified = person.IsMobileVerified, // IsMobileVerified
                Ssn = person.Ssn, // SSN (length: 100)
                IsAcknowledged = person.IsAcknowledged, // IsAcknowledged
                IsOnline = person.IsOnline, // IsOnline
                IsLimoOrTaxiDriver = person.IsLimoOrTaxiDriver, // IsLimoOrTaxiDriver
                EmailConfirmed = person.EmailConfirmed, // EmailConfirmed
                SecurityStamp = person.SecurityStamp, // SecurityStamp
                TwoFactorEnabled = person.TwoFactorEnabled, // TwoFactorEnabled
                LockoutEndDateUtc = person.LockoutEndDateUtc, // LockoutEndDateUtc
                LockoutEnabled = person.LockoutEnabled, // LockoutEnabled
                AccessFailedCount = person.AccessFailedCount, // AccessFailedCount
                UserName = person.UserName, // UserName (length: 256)
                PersonRoles = person.PersonRoles,
                Claims = person.AspNetUserClaims

            };

            return user;


        }

        public static implicit operator DTO.Entities.Person(CustomUser user)
        {

            DTO.Entities.Person person = new DTO.Entities.Person
            {

                ID = user.ID,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName, // MiddleName (length: 100)
                LastName = user.LastName, // LastName (length: 100)
                MobileCountryCode = user.MobileCountryCode, // MobileCountryCode (length: 50)
                MobilePhone = user.MobilePhone, // MobilePhone (length: 50)
                PrimaryEmail = user.PrimaryEmail, // PrimaryEmail (length: 100)
                Created = user.Created, // Created
                CreatedBy = user.CreatedBy, // CreatedBy (length: 100)
                Password = user.Password, // Password (length: 1000)
                IsSuspended = user.IsSuspended, // IsSuspended
                IsMobileVerified = user.IsMobileVerified, // IsMobileVerified
                Ssn = user.Ssn, // SSN (length: 100)
                IsAcknowledged = user.IsAcknowledged, // IsAcknowledged
                IsOnline = user.IsOnline, // IsOnline
                IsLimoOrTaxiDriver = user.IsLimoOrTaxiDriver, // IsLimoOrTaxiDriver
                EmailConfirmed = user.EmailConfirmed, // EmailConfirmed
                SecurityStamp = user.SecurityStamp, // SecurityStamp
                TwoFactorEnabled = user.TwoFactorEnabled, // TwoFactorEnabled
                LockoutEndDateUtc = user.LockoutEndDateUtc, // LockoutEndDateUtc
                LockoutEnabled = user.LockoutEnabled, // LockoutEnabled
                AccessFailedCount = user.AccessFailedCount, // AccessFailedCount
                UserName = user.UserName, // UserName (length: 256)
                PersonRoles = user.PersonRoles,
                AspNetUserClaims = user.Claims


            };

            return person;


        }
    }
}
