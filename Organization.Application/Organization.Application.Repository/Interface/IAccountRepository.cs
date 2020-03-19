using Organization.Application.DTO.Entities;
using Organization.Application.DTO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization.Application.DTO.Dtos;
using Organization.Application.Repository.Implementation;

namespace Organization.Application.Repository.Interface
{
    public interface IAccountRepository: IRepository<Person>
    {
        Task<Result<RegistrationResult>> Registor(Person person);
        Task<UserInformation> FindByEmail(string email);
 
        EmailTemplate GetEmail(string emailKey);

        Task<Person> GetByUserNameAsync(string name);

        Task<Person> CreateAsync(Person person);

        Task SaveMobileGeneratedVerificationCode(int personId, int Code);

        Task ApproveVerification(int personId);

        Task<IList<Role>> GetUserRolesByName(string name);




    }
}
