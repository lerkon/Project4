using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class MessageLocal
    {
        private int id;
        private string qustion;
        private PersonLocal ask;
        private List<AnswerLocal> answer;
        private DateTime time;
    }
}
