using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Organization.Application.Business.Helper
{

    public class CryptHelper
    {
        String iv = "8172e5fb8813e25b"; 
        string key ="3452frt67uy";
        string keySha256;
 
        CryptLib _CryptLib = new CryptLib();
        public CryptHelper()
        {
           keySha256=  CryptLib.getHashSha256(key, 32); //32 bytes = 256 bits
        }

        public string Decrypt(string encryptedStr)
        {

           string decryptedStr=  _CryptLib.decrypt(encryptedStr, keySha256, iv);

           return decryptedStr;
        }
        public string Encrypt(string stringToEncrypt)
        {

            string decryptedStr = _CryptLib.encrypt(stringToEncrypt, keySha256, iv);

            return decryptedStr;
        }
    }
}
