using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class VideoDefinition
    {
        [Key]
        public int VideoId { get; set; }

        public string Title { get; set; }

        [Required]
        public string Link { get; set; }
        

    }
}
