using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class EssayDefinition
    {
        [Key]
        public int EssayId { get; set; }

        public string Title { get; set; }

        public DateTime UploadDate { get; set; }

        [Required]
        public byte[] Content { get; set; }

    }
}
