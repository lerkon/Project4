using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CompanyLocal
    {
        public string name { get; set; }
        public string link { get; set; }
        public string description { get; set; }

        public CompanyLocal() { }
        public CompanyLocal(string name, string link, string description)
        {
            this.name = name;
            this.link = link;
            this.description = description;
        }
    }
}
