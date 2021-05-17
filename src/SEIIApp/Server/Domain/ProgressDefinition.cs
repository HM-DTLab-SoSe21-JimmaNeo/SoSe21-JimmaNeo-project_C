using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class ProgressDefinition
    {
        public int ModulId { get; set; }

        [ForeignKey("ModulId")]
        public ModulDefinition Modul { get; set; }

        public int Percentage { get; set; }

    }
}
