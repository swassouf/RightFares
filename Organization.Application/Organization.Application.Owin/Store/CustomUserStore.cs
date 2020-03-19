using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq.Expressions;
using System.Reflection;
using Organization.Application.Business.Interface;
using Microsoft.Practices.ServiceLocation;
using Organization.Application.Business.Properties;
using System.Globalization;

namespace Organization.Application.Owin.Store
{
    public class CustomUserStore :
        IUserStore<CustomUser>,
        IRoleStore<CustomRole, string>,
        IUserRoleStore<CustomUser, string>,
        IUserClaimStore<CustomUser>,
        IUserEmailStore<CustomUser>,
        IUserLockoutStore<CustomUser, string>,
         IUserLoginStore<CustomUser>,
        IUserPasswordStore<CustomUser>,
        IUserPhoneNumberStore<CustomUser>,
        IUserSecurityStampStore<CustomUser>,
         IQueryableUserStore<CustomUser>,
        IUserTwoFactorStore<CustomUser, string>
    {
        public IQueryable<CustomUser> Users
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public async Task AddClaimAsync(CustomUser user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            var commonBL = ServiceLocator.Current.GetInstance<ICommonBL<DTO.Entities.AspNetUserClaim>>();

            var userClaim = new DTO.Entities.AspNetUserClaim { PersonId = user.ID, ClaimType = claim.Type, ClaimValue = claim.Value };
            await commonBL.AddEntityAsync(userClaim);

        }

        public Task AddLoginAsync(CustomUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public async Task AddToRoleAsync(CustomUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (String.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException(Resources.ValueCannotBeNullOrEmpty, "roleName");
            }

            var roleBL = ServiceLocator.Current.GetInstance<IRoleBL>();
            var role = await roleBL.FindRoleByNameAsync(roleName);
            if (role == null)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture,
                   Resources.RoleNotFound, roleName));
            }

            var commonBL = ServiceLocator.Current.GetInstance<ICommonBL<DTO.Entities.PersonRole>>();

            var personRole = new DTO.Entities.PersonRole
            {
                PersonId = user.ID,
                RoleId = role.ID
            };

            await commonBL.AddEntityAsync(personRole);

        }

        public Task CreateAsync(CustomRole role)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(CustomUser user)
        {
            var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();
            var personAdded = await accountBL.CreateAsync(user);
            user.ID = personAdded.ID;
        }

        public Task DeleteAsync(CustomRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public Task<CustomUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<CustomUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomUser> FindByIdAsync(string userId)
        {
            var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();
            return await accountBL.FindByIdAsync(Convert.ToInt32(userId), x => x.PersonRoles, x => x.AspNetUserClaims);
        }
        
        public async Task<CustomUser> FindByNameAsync(string userName)
        {
            var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();
            CustomUser user = await accountBL.GetByUserNameAsync(userName);
             
            return user;
        }

        public Task<int> GetAccessFailedCountAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.AccessFailedCount);
        }

        public  Task<IList<Claim>> GetClaimsAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            var claims = user.Claims.Select(c => new Claim(c.ClaimType, c.ClaimValue)).ToList();

            return Task.FromResult<IList<Claim>>(claims);
        }

        public Task<string> GetEmailAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.PrimaryEmail);
        }

        public Task<bool> GetEmailConfirmedAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task<bool> GetLockoutEnabledAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return
                Task.FromResult(user.LockoutEndDateUtc.HasValue
                    ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                    : new DateTimeOffset());
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(CustomUser user)
        {
            //if (user == null)
            //{
            //    throw new ArgumentNullException("user");
            //}
            //await EnsureLoginsLoaded(user).WithCurrentCulture();
            //return user.Logins.Select(l => new UserLoginInfo(l.LoginProvider, l.ProviderKey)).ToList();
            IList<UserLoginInfo> uinfo = new List<UserLoginInfo>();
            return Task.FromResult(uinfo);
        }

        public Task<string> GetPasswordHashAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.Password);
        }

        public Task<string> GetPhoneNumberAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(String.Concat(user.MobileCountryCode, user.MobilePhone));
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.IsMobileVerified);
        }

        public async Task<IList<string>> GetRolesAsync(CustomUser user)
        {
            var roleBL = ServiceLocator.Current.GetInstance<IRoleBL>();
            var userRoles = await roleBL.GetRolesAsync(user.ID);
            var roleNames = userRoles.Select(r => r.Role.Name).ToList();

            return roleNames;

        }

        public Task<string> GetSecurityStampAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.SecurityStamp);
        }

        public Task<bool> GetTwoFactorEnabledAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task<bool> HasPasswordAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.AccessFailedCount++;
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> IsInRoleAsync(CustomUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(CustomUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(CustomUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(CustomUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(CustomUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.AccessFailedCount = 0;
            return Task.FromResult(0);
        }

        public Task SetEmailAsync(CustomUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(CustomUser user, bool confirmed)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.EmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public Task SetLockoutEnabledAsync(CustomUser user, bool enabled)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.LockoutEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task SetLockoutEndDateAsync(CustomUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
        {

            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetPhoneNumberAsync(CustomUser user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(CustomUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(CustomUser user, string stamp)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(CustomUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomRole role)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CustomUser user)
        {
            var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();

             await accountBL.UpdateAsync(user);

        }

        Task<CustomRole> IRoleStore<CustomRole, string>.FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        Task<CustomRole> IRoleStore<CustomRole, string>.FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        

        //private async Task EnsureClaimsLoaded(CustomUser user)
        //{
        //    if (!AreClaimsLoaded(user))
        //    {
        //        var userId = user.Id;
        //        await _userClaims.Where(uc => uc.UserId.Equals(userId)).LoadAsync().WithCurrentCulture();
        //        Context.Entry(user).Collection(u => u.Claims).IsLoaded = true;
        //    }
        //}

        // We want to use FindAsync() when looking for an User.Id instead of LINQ to avoid extra 
        // database roundtrips. This class cracks open the filter expression passed by 
        // UserStore.FindByIdAsync() to obtain the value of the id we are looking for 
        private static class FindByIdFilterParser
        {
            // expression pattern we need to match
            private static readonly Expression<Func<CustomUser, bool>> Predicate = u => u.Id.Equals(default(CustomUser));
            // method we need to match: Object.Equals() 
            private static readonly MethodInfo EqualsMethodInfo = ((MethodCallExpression)Predicate.Body).Method;
            // property access we need to match: User.Id 
            private static readonly MemberInfo UserIdMemberInfo = ((MemberExpression)((MethodCallExpression)Predicate.Body).Object).Member;

            internal static bool TryMatchAndGetId(Expression<Func<CustomUser, bool>> filter, out string id)
            {
                // default value in case we can’t obtain it 
                id = default(string);

                // lambda body should be a call 
                if (filter.Body.NodeType != ExpressionType.Call)
                {
                    return false;
                }

                // actually a call to object.Equals(object)
                var callExpression = (MethodCallExpression)filter.Body;
                if (callExpression.Method != EqualsMethodInfo)
                {
                    return false;
                }
                // left side of Equals() should be an access to User.Id
                if (callExpression.Object == null
                    || callExpression.Object.NodeType != ExpressionType.MemberAccess
                    || ((MemberExpression)callExpression.Object).Member != UserIdMemberInfo)
                {
                    return false;
                }

                // There should be only one argument for Equals()
                if (callExpression.Arguments.Count != 1)
                {
                    return false;
                }

                MemberExpression fieldAccess;
                if (callExpression.Arguments[0].NodeType == ExpressionType.Convert)
                {
                    // convert node should have an member access access node
                    // This is for cases when primary key is a value type
                    var convert = (UnaryExpression)callExpression.Arguments[0];
                    if (convert.Operand.NodeType != ExpressionType.MemberAccess)
                    {
                        return false;
                    }
                    fieldAccess = (MemberExpression)convert.Operand;
                }
                else if (callExpression.Arguments[0].NodeType == ExpressionType.MemberAccess)
                {
                    // Get field member for when key is reference type
                    fieldAccess = (MemberExpression)callExpression.Arguments[0];
                }
                else
                {
                    return false;
                }

                // and member access should be a field access to a variable captured in a closure
                if (fieldAccess.Member.MemberType != MemberTypes.Field
                    || fieldAccess.Expression.NodeType != ExpressionType.Constant)
                {
                    return false;
                }

                // expression tree matched so we can now just get the value of the id 
                var fieldInfo = (FieldInfo)fieldAccess.Member;
                var closure = ((ConstantExpression)fieldAccess.Expression).Value;

                id = (string)fieldInfo.GetValue(closure);
                return true;
            }
        }



        //
    }
}
