using System;
using System.Collections.Generic;

namespace SEIIApp.Shared.ContentDto
{
    public class Content
    {
        public int ContentId { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public bool IsAuthorized { get; set; }
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastChanged { get; set; }
        public int Likes { get; set; }
        public int CommentCounter { get; set; }
        public List<CommentDto> Comments { get; set; }
        public ContentType Type { get; set; }
        //TODO change to image datatype
        public byte[] Thumbnail { get; set; }

        public void Like()
        {
            Likes++;
        }

        public void AddComment(string title, string content)
        {
            CommentDto comment = new CommentDto(title, content);
            
            Comments.Add(comment);
        }
    }
}