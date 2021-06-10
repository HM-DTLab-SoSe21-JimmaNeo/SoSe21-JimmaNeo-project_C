using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class QuestionDefinition
    {
        [Key]
        public int QuestionId { get; set; }

        public string Question { get; set; }

        public bool IsCorrect { get; set; }

        //public List<AnswerOption> AnswerOptions { get; set; }
        public List<AnswerOptionDefinition> AnswerOptions { get; set; } = new List<AnswerOptionDefinition>();
    }
}
