using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Person
    {
        private int id;
        private string login;
        private string password;
        private string name;
        private string surname;
        private Company company;
        private List<Item> itemsSold;
        private List<Item> itemsBought;
        private int zipCode;
        private string email;
        private string phone;
        private string city;
        private string address;
    }
}
