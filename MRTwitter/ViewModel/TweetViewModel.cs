using MRTwitter.Helpers;

namespace MRTwitter.ViewModel
{
    public class TweetViewModel
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string CreatedAt { get; set; }

        public UserViewModel User { get; set; }
        public string CreatedAtString
        {
            get { return TextHelper.PrepareDate(this.CreatedAt); }
        }
        public string TextShortVersion
        {
            get { return TextHelper.PrepareShortText(this.TextShortVersion); }
        }
    }
}