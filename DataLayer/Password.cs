using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Security.Cryptography;

namespace DataLayer
{
    public class Password
    {
        public Person login(string login, string password)
        {
            string[] dbData = getPasswordSaltDB(login);
            if (dbData != null)
            {
                if (comparePasswords(password, dbData[0], dbData[1]) == true)
                {
                    return new PersonDB().getPerson(login);
                }
                else
                    return null;
            }
            else
                return null;
        }

        private string[] getPasswordSaltDB(string login)
        {
            string[] data = null;
            var person = PHEntities.Admin.Where(a => a.login == login);
            if (data.FirstOrDefault() != null)
                data = new string[] { person.First().pass, person.First().salt, person.First().id.ToString() };
        }

        public string[] getFullyHash(string password)
        {
            string salt = getRandomNumber(20);
            return new string[] { getPBKDF2(password, salt), salt };
        }

        private string getRandomNumber(int byteSize)
        {
            RNGCryptoServiceProvider generate = new RNGCryptoServiceProvider();
            byte[] number = new byte[byteSize];
            generate.GetBytes(number);

            return Convert.ToBase64String(number);
        }

        private bool comparePasswords(string password, string hash, string salt)
        {
            if (getPBKDF2(password, salt).Equals(hash))
                return true;
            else
                return false;
        }

        private string getPBKDF2(string password, string salt)
        {
            Rfc2898DeriveBytes hash = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), 6000);
            return Convert.ToBase64String(hash.GetBytes(50));
        }
    }
}
