using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataLayer;

namespace ControlLayer
{
    public class PasswordControl
    {
        public Person login(string login, string password, ref string message)
        {
            return new Password().login(login, password);
        }
    }
}