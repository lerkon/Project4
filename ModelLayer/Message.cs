using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Message
    {
        private int id;
        private string qustion;
        private Person ask;
        private List<Answer> answer;
        private DateTime time;
    }
}
