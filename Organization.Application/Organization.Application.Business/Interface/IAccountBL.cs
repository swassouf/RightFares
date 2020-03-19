using Organization.Application.DTO.Dtos;
using Organization.Application.DTO.Entities;
using Organization.Application.DTO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Business.Interface
{
    public interface IAccountBL
    {
        Task<Result<RegistrationResult>> Registor(Person person);
        Task<UserInformation> FindByEmail(string email);
        Task<Person> FindByIdAsync(int personId, params Expression<Func<Person, Object>>[] includeProperties);
        bool CheckPasswordHash(string passwordHas, string password);
        EmailTemplate GetEmail(string emailKey);

        Task<Person> GetByUserNameAsync(string name);

        Task<Person> CreateAsync(Person person);

        Task<Person> UpdateAsync(Person person);

        Task SaveMobileGeneratedVerificationCode(int personId, int Code);

        Task ApproveVerification(int personId);
        Task<IList<Role>> GetUserRolesByName(string name);



    }
}
