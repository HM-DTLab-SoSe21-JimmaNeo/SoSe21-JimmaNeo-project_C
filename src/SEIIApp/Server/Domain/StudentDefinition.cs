using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class StudentDefinition : UserDefinition 
    {
        public List<ProgressDefinition> Progresses { get; set; } = new List<ProgressDefinition>();
        public List<ModulDefinition> Moduls { get; set; } = new List<ModulDefinition>();
    }
}
