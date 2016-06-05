using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CommentLocal
    {
        public int id { get; set; }
        public PersonLocal person { get; set; }
        public string comment { get; set; }
        public DateTime commentDay { get; set; }
        public CommentLocal() { }
    }
}