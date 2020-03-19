using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Organization.Application.DTO.Entities;
using Organization.Application.Repository.Context;
using Constants = Organization.Application.DTO.Constants;
using Organization.Application.DTO.Implementation;
using Organization.Application.DTO.Dtos;
using Organization.Application.Repository.Interface;

namespace Organization.Application.Repository.Implementation
{
    public class AccountRepository : Repository<Person>, IAccountRepository
    {
        public Task<Result<RegistrationResult>> Registor(Person person)
        {
            int roleId = person.PersonRoles.Select(r => r.RoleId).First();

            var result = new Result<RegistrationResult>();
            result.Value = new RegistrationResult();

            using (var ctx = new DispatchContext())
            {
                int customerId = (from p in ctx.People
                                  join pr in ctx.PersonRoles
                                  on p.ID equals pr.PersonId
                                  where p.PrimaryEmail.Trim() == person.PrimaryEmail.Trim()
                                  && pr.RoleId == roleId
                                  select p.ID).FirstOrDefault();
                if (customerId != 0)
                {
                    result.Value.IsExists = true;
                    return Task.FromResult(result);
                }

                if (roleId == Constants.Roles.Customer)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(10000);
                    person.MobileVerifications = new MobileVerification[] { new MobileVerification { VerificationCode = 123, Created = DateTime.UtcNow } };
                    result.Value.MobileConfirmationNumber = randomNumber;
                }

                ctx.People.Add(person);
                ctx.SaveChanges();

                return Task.FromResult(result);

            }
        }

        public Task<UserInformation> FindByEmail(string email)
        {
            using (var ctx = new DispatchContext())
            {
                var userInfo = ctx.People.Include("Role").Where(p => p.PrimaryEmail == email)
                    .Select(u => new UserInformation
                    {
                        Id = u.ID,
                        Email = u.PrimaryEmail,
                        MobileCountryCode = u.MobileCountryCode,
                        PhoneNumber = u.MobilePhone,
                        Roles = u.PersonRoles,
                        PasswordHash = u.Password

                    }).FirstOrDefault();

                return Task.FromResult(userInfo);
            }
        }

        public EmailTemplate GetEmail(string emailKey)
        {
            using (var ctx = new DispatchContext())
            {
                return ctx.EmailTemplates.Where(t => t.EmailKey == emailKey).FirstOrDefault();
            }

        }

        public async Task<IList<Role>> GetUserRolesByName(string name)
        {
            using (var ctx = new DispatchContext())
            {
                var result = (from p in ctx.People
                              join pr in ctx.PersonRoles
                              on p.ID equals pr.PersonId
                              join r in ctx.Roles
                              on pr.RoleId equals r.ID
                              where p.UserName == name
                              select r).ToListAsync();
                return await result;
            }
        }

        public Task<Person> GetByUserNameAsync(string name)
        {
            using (var ctx = new DispatchContext())
            {
                return Task.FromResult(ctx.People.Include("PersonRoles").Include("AspNetUserClaims").Where(p => p.UserName == name).FirstOrDefault());
            }
        }

        public Task<Person> CreateAsync(Person person)
        {
            var addedEntity = this.CreateEntity(person);
            return Task.FromResult(addedEntity);
        }

        public async Task SaveMobileGeneratedVerificationCode(int personId, int Code)
        {
            using (var ctx = new DispatchContext())
            {
                DTO.Entities.MobileVerification mv = new MobileVerification
                {
                    PersonId = personId,
                    VerificationCode = Code
                };

                ctx.MobileVerifications.Add(mv);

                await ctx.SaveChangesAsync();
            }
        }

        public async Task ApproveVerification(int personId)
        {
            using (var ctx = new DispatchContext())
            {
                var person = ctx.People.Include("AspNetUserClaims").Where(p => p.ID == personId).First();
                person.IsMobileVerified = true;
                person.TwoFactorEnabled = false;
                var claim = person.AspNetUserClaims.Where(c => c.ClaimType == "Verification").First();
                claim.ClaimValue = "1";

                await ctx.SaveChangesAsync();
            }
        }

    }
}
