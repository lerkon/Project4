using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;

namespace ServiceLayer
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        [FaultContract(typeof(PersonFault))]
        Person login(string login, string password, ref string message);

        [OperationContract]
        [FaultContract(typeof(PersonFault))]
        Person setPerson(ref PersonLocal person, ref string message);
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string FaultMessage { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string surname { get; set; }
        [DataMember]
        public int zipCode { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        private Company company { get; set; }
        //private List<Item> itemsSold;
        //private List<Item> itemsBought;
    }

    [DataContract]
    public class Company
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int link { get; set; }
        [DataMember]
        public string description { get; set; }
    }

    [DataContract]
    public class PersonFault
    {
        public PersonFault(string msg)
        {
            FaultMessage = msg;
        }

        [DataMember]
        public string FaultMessage;
    }
}