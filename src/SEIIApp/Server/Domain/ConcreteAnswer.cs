using SEIIApp.Shared.DomainTdo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{

    public class ConcreteAnswer
    {

        public bool SelectedAnswer { get; set; }

        public AnswerDefinitionDto ReferencesTo { get; set; }
   

    }

}

