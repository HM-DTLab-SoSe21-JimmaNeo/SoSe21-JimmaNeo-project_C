using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEIIApp.Shared
{
    public class PostDto
    {
            
        public int PostId { get; set; }
        public int UserId { get; set; }
        //public bool IsAuthorized { get; set; }

        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public string Content { get; set; }
        public byte[] Attachment { get; set; }
        public int Likes { get; set; }
        public int CommentCounter { get; set; }
        public string Comment { get; set; }
        public string Category { get; set; }

        //public UrlAttribute Link { get; set; }

      

    }
}
