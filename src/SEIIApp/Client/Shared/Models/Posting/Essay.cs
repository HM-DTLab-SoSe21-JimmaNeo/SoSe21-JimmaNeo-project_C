namespace SEIIApp.Client.Shared.Models.Posting
{
    public class Essay : Post
    {
        public string Content { get; set; }


        public Essay(string title)
        {
            this.Title = title;
        }
    }
}