using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Person
    {
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Company company { get; set; }
        public List<Item> itemsSold { get; set; }
        public List<Item> itemsBought { get; set; }
        public int zipCode { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string address { get; set; }

        public Person(string login, string password, string name, string surname,
            int zipCode, string email, string phone, string city, string address)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.zipCode = zipCode;
            this.email = email;
            this.phone = phone;
            this.city = city;
            this.address = address;
            itemsSold = new List<Item>();
            itemsBought = new List<Item>();
        }
    }
}
