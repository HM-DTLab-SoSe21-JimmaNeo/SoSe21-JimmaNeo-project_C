﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class PostDefinition
    {
        [Key]
        public int PostId { get; set; }

        public int UserId { get; set; }

        //[ForeignKey("UserId")]
        //public UserDefinition User { get; set; }

        public String Category { get; set; }

        //[Required]
        //public bool IsAuthorized { get; set; }

        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastChange { get; set; }
        public string Content { get; set; }
        public byte[] Attachment { get; set; }
        public int Likes { get; set; }
        public int CommentCounter { get; set; }
        //public List<CommentDefinition> Comments { get; set; } = new List<CommentDefinition>();

        public String UrlLink { get; set; }
        //public List<String> Links { get; set; }

        //public List<CommentDefinition> Comments { get; set; }

    }
}