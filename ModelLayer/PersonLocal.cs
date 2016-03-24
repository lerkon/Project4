using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class PersonLocal
    {
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public CompanyLocal company { get; set; }
        public List<ItemLocal> itemsSold { get; set; }
        public List<ItemLocal> itemsBought { get; set; }
        public int zipCode { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string address { get; set; }

        public PersonLocal() { }
        //itemsSold = new List<Item>();
        //itemsBought = new List<Item>();
    }
}
