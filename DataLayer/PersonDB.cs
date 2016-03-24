using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DataLayer
{
    class PersonDB
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
    }
}
