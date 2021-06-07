using System;

namespace SEIIApp.Shared.ContentDto
{
    public class Paper : Content
    {
        public string[] Authors { get; set; }
        public string PublishingHouse { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime PublicationDate { get; set; }
        

        public Paper(string title)
        {
            this.Title = title;
        }
    }
}