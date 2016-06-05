using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ModelLayer
{
    public class ItemLocal
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public int stockRemained { get; set; }
        public DateTime startAuction { get; set; }
        public DateTime endAuction { get; set; }
        public List<OrderLocal> orders { get; set; }
        public List<CommentLocal> comments { get; set; }
        public string description { get; set; }
        public byte[][] img { get; set; }
        public byte[] rowVersion { get; set; }
        public string category { get; set; }
        public ItemLocal() { }
    }
}