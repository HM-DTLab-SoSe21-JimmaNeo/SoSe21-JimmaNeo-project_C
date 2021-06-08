using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class QuizDto
    {
        public int QuizId { get; set; }

        public string QuizName { get; set; }

        public int Score { get; set; }

        public int Percentage { get; set; }

        public List<QuestionDto> Questions { get; set; }
    }
}
