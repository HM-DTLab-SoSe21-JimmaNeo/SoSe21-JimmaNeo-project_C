using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class CommentDefinition
    {
        [Key]
        public int CommentId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserDefinition User { get; set; }

        [Required]
        public bool IsAuthorized { get; set; }

        public string Content { get; set; }
        public DateTime UploadDate { get; set; }
        public byte[] Attachment { get; set; }
        public int Likes { get; set; }

    }
}
