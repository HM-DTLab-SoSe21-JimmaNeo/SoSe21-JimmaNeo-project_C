using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainTdo {
    public class ConcreteAnswerDto {

        public bool SelectedAnswer { get; set; }

        public AnswerDefinitionDto ReferencesTo { get; set; }


    }
}
