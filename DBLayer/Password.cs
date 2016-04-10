using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Security.Cryptography;
using DBLayer;

namespace DataLayer
{
    public class Password
    {
        public PersonLocal login(string login, string password, ref string message)
        {
            string[] dbData = getPasswordSaltDB(login);
            if (dbData != null)
            {
                if (comparePasswords(password, dbData[0], dbData[1]) == true)
                {
                    return new PersonDB().getPerson(int.Parse(dbData[2]));
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
            using (var enities = new dmaj0914_2Sem_5Entities1())
            {
                var person = enities.People.Where(a => a.login == login).FirstOrDefault();
                if (person != null)
                    data = new string[] { person.password, person.salt, person.id.ToString() };
            }
            return data;
        }

        public string[] getPasswordNewUser(string password)
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
