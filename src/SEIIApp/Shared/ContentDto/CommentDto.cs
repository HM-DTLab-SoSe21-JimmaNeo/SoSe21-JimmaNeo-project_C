using System;

namespace SEIIApp.Shared.ContentDto
{
    public class CommentDto
    {
        private string Title { get; set; }
        private string Content { get; set; }
        private DateTime UploadDate { get; set; }
        private DateTime LastChanged { get; set; }

        public CommentDto(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }
}