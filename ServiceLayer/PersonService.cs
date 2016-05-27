using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;
using ControlLayer;

namespace ServiceLayer
{
    public class PersonService : IPersonService
    {
        public Person login(string login, string password, ref string message)
        {
            PersonLocal pl = new PersonControl().login(login, password, ref message);
            Person p = null;
            if (pl != null)
                p = personLocalToPerson(pl);
            return p;
        }

        public Person setPerson(Person person, ref string message)
        {
            PersonLocal p = personLocalFromPerson(person);
            new PersonControl().setPerson(ref p, ref message);
            return personLocalToPerson(p);
        }

        public Person personLocalToPerson(PersonLocal person)
        {
            Person p = new Person();
            p.address = person.address;
            p.city = person.city;
            p.email = person.email;
            p.id = person.id;
            p.login = person.login;
            p.name = person.name;
            p.password = person.password;
            p.phone = person.phone;
            p.surname = person.surname;
            p.zipCode = person.zipCode;
            if(person.company != null)
            {
                p.company = new Company();
                p.company.name = person.company.name;
                p.company.description = person.company.description;
                p.company.link = person.company.link;
            }
            return p;
        }

        public PersonLocal personLocalFromPerson(Person person)
        {
            PersonLocal p = new PersonLocal();
            p.address = person.address;
            p.city = person.city;
            p.email = person.email;
            p.id = person.id;
            p.login = person.login;
            p.name = person.name;
            p.password = person.password;
            p.phone = person.phone;
            p.surname = person.surname;
            p.zipCode = person.zipCode;
            if (person.company != null)
            {
                p.company = new CompanyLocal();
                p.company.name = person.company.name;
                p.company.description = person.company.description;
                p.company.link = person.company.link;
            }
            return p;
        }

        public bool updatePerson(Person person, ref string message)
        {
            return new PersonControl().updatePerson(personLocalFromPerson(person), ref message);
        }
    }
}