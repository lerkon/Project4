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
            throw new NotImplementedException();
        }

        public Person setPerson(Person person, ref string message)
        {
            PersonLocal p = personLocalFromPerson(person);
            new PersonControl().setPerson(ref p, ref message);
            return null;
        }

        public Person personLocalToPerson(PersonLocal person)
        {
            return null;
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
            p.company.description = person.company.description;
            p.company.link = person.company.link;
            p.company.name = person.company.name;
            return p;
        }
    }
}
