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

        public Person setPerson(ref PersonLocal person, ref string message)
        {
            person = new PersonLocal();
            person.login = "aaa";
            person.name = "aaa";
            person.surname = "aaa";
            person.company = null;
            person.itemsSold = null;
            person.itemsBought = null;
            person.zipCode = 1111;
            person.email = "aaa";
            person.phone = "aaa";
            person.city = "aaa";
            person.address = "aaa";
            person.password = "aaa";
            new PersonControl().setPerson(ref person, ref message);
            return null;
        }
    }
}
