using Organization.Application.Business.Helper;
using Organization.Application.DTO.Entities;
using Constancs = Organization.Application.DTO.Constants;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Organization.Application.Owin;
using System.Security.Claims;

namespace Organization.Application.Broker.Models
{
    public class RegisterViewModel
    {
        public int RoleID { get; set; }
        public IList<SelectListItem> RoleOptions { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string CountryCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string MobilePhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter Valid Email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public static implicit operator CustomUser(RegisterViewModel model)
        {
            var mobileCountryCode = Regex.Match(model.MobilePhoneNumber.Trim(), @"\d+").Value;
            var formatedMobilePhoneNumber = string.Join("", model.MobilePhoneNumber.Trim().Split(' ').Skip(1));
            var mobilePhoneNumber = new string(formatedMobilePhoneNumber.Where(char.IsDigit).ToArray());
            CryptHelper crypto = new CryptHelper();

            var person = new CustomUser
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                MobileCountryCode = mobileCountryCode,
                PrimaryEmail = model.Email,
                MobilePhone = mobilePhoneNumber,
                Password = model.Password,
                PersonRoles = new PersonRole[] { new PersonRole { RoleId = model.RoleID } },
                Claims = new AspNetUserClaim[] { new AspNetUserClaim { ClaimType = ClaimTypes.Role, ClaimValue = model.RoleID.ToString() }, new AspNetUserClaim { ClaimType = "Verification", ClaimValue = "0" } },
                Created = DateTime.UtcNow,
                CreatedBy = model.RoleID == Constancs.Roles.Customer ? "Customer" : "Driver",
                UserName = model.Email

            };

            return person;
        }

        //public static implicit operator RegisterViewModel(CustomUser user)
        //{

        //}
    }
}
