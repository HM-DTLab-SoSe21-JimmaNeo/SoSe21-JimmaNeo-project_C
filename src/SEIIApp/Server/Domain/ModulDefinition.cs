using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class ModulDefinition
    {
        [Key]
        public int ModulId { get; set; }

        public string Title { get; set; }

        public List<EssayDefinition> Essays { get; set; }

        public List<VideoDefinition> Videos { get; set; }

        public List<QuizDefinition> Quizes { get; set; }

    }
}
