using Organization.Application.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization.Application.DTO.Entities;
using Organization.Application.DTO.Implementation;
using Organization.Application.Repository.Interface;
using Organization.Application.DTO.Dtos;
using Organization.Application.Business.Helper;
using Constants = Organization.Application.DTO.Constants;
using Organization.Application.Business.Email;
using System.Linq.Expressions;

namespace Organization.Application.Business.Implementation
{
    public class AccountBL : IAccountBL
    {
        IAccountRepository _AccountRepository;

        public AccountBL(IAccountRepository accountRepository)
        {
            
            this._AccountRepository = accountRepository;
        }

        public async Task<Result<RegistrationResult>> Registor(Person person)
        {
            return await this._AccountRepository.Registor(person);
        }

        public async Task<UserInformation> FindByEmail(string email)
        {
            return await this._AccountRepository.FindByEmail(email);
        }

        public bool CheckPasswordHash(string passwordHash, string password)
        {
            CryptHelper crypto = new CryptHelper();
            string decryptedPass = crypto.Decrypt(passwordHash);
            return string.Equals(decryptedPass, password);
        }

        public EmailTemplate GetEmail(string emailKey)
        {
            return this._AccountRepository.GetEmail(emailKey);
        }


        public async Task<IList<Role>> GetUserRolesByName(string name)
        {
            return await this._AccountRepository.GetUserRolesByName(name);
        }

        public async Task<Person> CreateAsync(Person person)
        {
            return await this._AccountRepository.CreateAsync(person);
        }

        public async Task<Person> FindByIdAsync(int personId, params Expression<Func<Person, Object>>[] includeProperties)
        {
            return await _AccountRepository.GetByIdAsync(personId, includeProperties);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            return await _AccountRepository.UpdateAsync(person);
        }

        public async Task SaveMobileGeneratedVerificationCode(int personId, int Code)
        {
            await _AccountRepository.SaveMobileGeneratedVerificationCode(personId, Code);
        }

        public async Task ApproveVerification(int personId)
        {
            await _AccountRepository.ApproveVerification(personId);
        }
        public async Task<Person> GetByUserNameAsync(string name)
        {
            return await this._AccountRepository.GetByUserNameAsync(name);
        }

    }
}
