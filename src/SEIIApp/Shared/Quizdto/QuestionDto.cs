using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }

        public string Question { get; set; }

        public bool IsCorrect { get; set; }

        public List<AnswerOptionDto> AnswerOptions { get; set; } = new List<AnswerOptionDto>();
    }
}
