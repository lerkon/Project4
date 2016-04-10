using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataLayer;

namespace DBLayer
{
    public class PersonDB
    {
        public PersonLocal getPerson(int id)
        {
            PersonLocal p = null;
            using (var enities = new dmaj0914_2Sem_5Entities1())
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

        public bool updatePerson(PersonLocal person)
        {
            string[] data = new Password().getPasswordNewUser(person.password);
            bool ok = false;
            using (var enities = new dmaj0914_2Sem_5Entities1())
            {
                var p = enities.People.Where(a => a.id == person.id).FirstOrDefault();
                p.id = person.id;
                p.address = person.address;
                p.city = person.city;
                p.email = person.email;
                p.login = person.login;
                p.name = person.name;
                p.password = data[0];
                p.phone = person.phone;
                p.salt = data[1];
                p.surname = person.surname;
                p.zipCode = person.zipCode;
                if (enities.SaveChanges() != 0)
                {
                    var c = enities.Companies.Where(a => a.personId == p.id).FirstOrDefault();
                    if (c != null && person.company != null)
                        ok = new CompanyDB().updateCompany(person);
                    else if (c != null && person.company == null)
                        ok = new CompanyDB().deleteCompany(person);
                    else if (c == null && person.company != null)
                        ok = new CompanyDB().setCompany(person);
                    else if (c == null && person.company == null)
                        ok = true;
                    return true;
                }
                else
                    return ok;
            }
        }

        public bool setPerson(ref PersonLocal person)
        {
            using (var enities = new dmaj0914_2Sem_5Entities1())
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
                    new CompanyDB().setCompany(person);
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
