
namespace SEIIApp.Shared.ContentDto
{
    public class VideoDto : Content
    {
        
        public int VideoId { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }


        public VideoDto(string title)
        {
            this.Title = title;
        }
    }
}