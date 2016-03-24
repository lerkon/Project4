using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DBLayer;
using DataLayer;

namespace ControlLayer
{
    public class PersonControl
    {
        public PersonLocal login(string login, string password, ref string message)
        {
            PersonLocal p = new Password().login(login, password);
            if (p != null)
                return p;
            else
            {
                message = "Try once again.";
                return null;
            }
        }

        public bool setPerson(ref PersonLocal person, ref string message)
        {
            bool ok = new PersonDB().setPerson(ref person);
            if (ok != true)
                message = "Try once again.";
            return ok;
        }
    }
}
