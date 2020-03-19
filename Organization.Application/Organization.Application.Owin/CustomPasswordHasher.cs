using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization.Application.Business.Helper;

namespace Organization.Application.Owin
{
    public class CustomPasswordHasher : IPasswordHasher
    {
  

        public string HashPassword(string password)
        {
            CryptHelper crypto = new CryptHelper();
            return crypto.Encrypt(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            CryptHelper crypto = new CryptHelper();
            string decryptedPassword = crypto.Decrypt(hashedPassword);

            if (string.Equals(decryptedPassword, providedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }
    }


}
