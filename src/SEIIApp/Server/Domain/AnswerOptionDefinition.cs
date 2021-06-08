using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class AnswerOptionDefinition
    {
        [Key]
        public int AnswerOptionId { get; set; }
        public string Option { get; set; }
        public bool isCorrect { get; set; }

    }
}
