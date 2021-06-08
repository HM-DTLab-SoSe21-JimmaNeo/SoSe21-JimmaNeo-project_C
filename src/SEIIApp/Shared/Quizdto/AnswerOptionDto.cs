using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class AnswerOptionDto
    {
        public int AnswerOptionId { get; set; }
        public string Option { get; set; }
        public bool isCorrect { get; set; }
    }
}
