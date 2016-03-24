using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DBLayer;

namespace DataLayer
{
    public class PersonDB
    {
        public PersonLocal getPerson(int id)
        {
            PersonLocal p = null;
            using (var enities = new dmaj0914_2Sem_5Entities())
            {
                var person = enities.People.Where(a => a.id == id).FirstOrDefault();
                if (person != null)
                {
                    p = new PersonLocal();
                    p.login = person.login;
                    p.name = person.name;
                    p.surname = person.surname;
                    p.company = new CompanyDB().getCompany(id);
                    p.itemsSold = null;
                    p.itemsBought = null;
                    p.zipCode = person.zipCode;
                    p.id = person.id;
                    p.email = person.email;
                    p.phone = person.phone;
                    p.city = person.city;
                    p.address = person.address;
                }
            }
            return p;
        }

        public bool setPerson(ref PersonLocal person)
        {
            using (var enities = new dmaj0914_2Sem_5Entities())
            {
                string[] data = new Password().getPasswordNewUser(person.password);
                enities.People.Add(new Person()
                {
                    name = person.name,
                    login = person.login,
                    surname = person.surname,
                    zipCode = person.zipCode,
                    id = person.id,
                    email = person.email,
                    phone = person.phone,
                    city = person.city,
                    address = person.address,
                    password = data[0],
                    salt = data[1]
                });
                int ok = enities.SaveChanges();
                if (ok == 1)
                {
                    string l = person.login;
                    person.id = enities.People.Where(a => a.login == l).FirstOrDefault().id;
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
