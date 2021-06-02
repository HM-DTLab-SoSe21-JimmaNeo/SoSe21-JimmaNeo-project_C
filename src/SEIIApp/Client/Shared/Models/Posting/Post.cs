using System;
using System.Collections.Generic;
using System.Drawing;
using SEIIApp.Client.Shared.Components;

namespace SEIIApp.Client.Shared.Models.Posting
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsAuthorized { get; set; }
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastChange { get; set; }
        private int Likes { get; set; }
        public int CommentCounter { get; set; }
        private List<Comment> Comments { get; }
        public PostTypes Type { get; set; }
        //TODO change to Image DataType
        public byte[] Thumbnail;

        public void Like()
        {
            Likes++;
        }

        public void AddComment(string title, string content)
        {
            var comment = new Comment(title, content);
            
            Comments.Add(comment);
        }
    }
}