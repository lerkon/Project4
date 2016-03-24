using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLayer
{
    public class PersonService : IPersonService
    {
        public PersonS login(string login, string password, ref string message)
        {
            throw new NotImplementedException();
        }
    }
}
