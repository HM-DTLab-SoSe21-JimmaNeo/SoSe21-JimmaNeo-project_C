using System;
using SEIIApp.Client.Shared.Components;

namespace SEIIApp.Client.Shared.Models.Posting
{
    public class Comment
    {
        private int UserId;
        private User User;
        private string Title;
        private string Content;
        private DateTime PostTime;
        private DateTime LastChanged;

        public Comment(string title, string content)
        {
            this.Title = title;
            this.Content = content;
            this.PostTime = DateTime.Now;
            this.LastChanged = DateTime.Now;
            // get current logged in user: this.User = getCurrentUser();
        }
    }
}