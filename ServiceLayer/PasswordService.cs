using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ControlLayer;
using ModelLayer;

namespace ServiceLayer
{
    public class PasswordService : IPasswordService
    {
        PasswordControl pas = new PasswordControl();

        public Person login(string login, string password, ref string message)
        {
            Person person = null;
            try
            {
                person = pas.login(login, password, ref message);
            }
            catch (Exception e)
            {
                var msg = e.Message;
                var reason = "service login exception";
                throw new FaultException<PasswordFault>(new PasswordFault(msg), reason);
            }
            return person;
        }
    }
}