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
    }
}
