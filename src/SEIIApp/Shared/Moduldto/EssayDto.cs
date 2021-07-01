using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class EssayDto
    {
        public int EssayId { get; set; }

        public string Title { get; set; }

        public DateTime UploadDate { get; set; }

        public byte[] Content { get; set; }

        public EssayDto(string title)
        {
            Title = title;
        }

        public EssayDto(string title, DateTime uploadDate, byte[] content)
        {
            Title = title;
            UploadDate = uploadDate;
            Content = content;
        }
    }
}
