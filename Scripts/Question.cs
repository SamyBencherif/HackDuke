using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.HackDuke.scripts
{
    [Serializable]
    public class Question
    {
        public int QuestionId = 0;
        public string Title = "";
        public short Category = 0;
        public string Body = "";
        public bool ShortAnswer = false;
        public bool MultipleChoice = false;
        public bool TrueFalse = false;
        public string A = "";
        public string B = "";
        public string C = "";
        public string D = "";
        public string E = "";
        public string Answer = "";
    }
}
