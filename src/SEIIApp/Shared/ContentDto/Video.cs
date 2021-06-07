namespace SEIIApp.Shared.ContentDto
{
    public class Video : Content
    {
        public byte[] VideoFile { get; set; }

        public Video(string title)
        {
            this.Title = title;
        }
    }
}