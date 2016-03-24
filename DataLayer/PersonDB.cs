using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataLayer
{
    public class PersonDB
    {
        public Person getPerson(int id)
        {
            Person p = null;
            using (var enities = new Entities())
            {
                var person = enities.Personns.Where(a => a.id == id).FirstOrDefault();
                if (person != null)
                {
                    p = new Person();
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

        public bool setPerson(ref Person person)
        {
            using (var enities = new Entities())
            {
                string[] data = new Password().getPasswordNewUser(person.password);
                enities.Personns.Add(new Personn()
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
                    person.id = enities.Personns.Where(a => a.login == l).FirstOrDefault().id;
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
