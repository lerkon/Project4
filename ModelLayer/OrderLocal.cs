using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class OrderLocal
    {
        public int id;
        public int amount { get; set; }
        public int totalPrice { get; set; }
        public PersonLocal buyer { get; set; }
        public DateTime buyDay { get; set; }
        public OrderLocal() { }
    }
}
