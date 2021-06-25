namespace SEIIApp.Shared
{
    public class VideoDto
    {
        public int VideoId { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public VideoDto(string title)
        {
            Title = title;
        }

        public VideoDto(string title, string link)
        {
            Title = title;
            Link = link;
        }
    }
}