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
        public PersonS login(string login, string password, ref string message)
        {
            throw new NotImplementedException();
        }

        public PersonS setPerson(ref Person person, ref string message)
        {
            person = new Person();
            person.address = "aaa";
            person.city = "aaa";
            person.company = null;
            person.email = "aaa";
            person.login = "aaa";
            person.name = "aaa";
            person.password = "aaa";
            person.phone = "aaa";
            person.surname = "aaa";
            person.zipCode = 2;
            PersonS ps = translateToPersonS(ref person);
            PersonControl pc = new PersonControl();
            translateFromPersonS(ref ps, ref person);
            pc.setPerson(ref person, ref message);
            return translateToPersonS(ref person);
        }

        public PersonS translateToPersonS(ref Person p)
        {
            PersonS ps = new PersonS();
            ps.address = p.address;
            ps.city = p.city;
            ps.email = p.email;
            ps.id = p.id;
            ps.login = p.login;
            ps.name = p.login;
            ps.password = p.password;
            ps.phone = p.phone;
            ps.surname = p.surname;
            ps.zipCode = p.zipCode;
            return ps;
        }

        public void translateFromPersonS(ref PersonS p, ref Person ps)
        {
            //Person ps = new Person();
            ps.address = p.address;
            ps.city = p.city;
            ps.email = p.email;
            ps.id = p.id;
            ps.login = p.login;
            ps.name = p.login;
            ps.password = p.password;
            ps.phone = p.phone;
            ps.surname = p.surname;
            ps.zipCode = p.zipCode;
            //return ps;
        }
    }
}
