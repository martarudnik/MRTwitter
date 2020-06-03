using System.Configuration;

namespace MRTwitter.Constants
{
    public class TwitterEndpointUrlConstants
    {
        public static readonly string FullUrl = ConfigurationManager.AppSettings["TwitterApiBaseUrl"];
        public static readonly string GetStatutes = FullUrl + "statuses/user_timeline.json";
        public static readonly string GetSearchTweets = FullUrl + "search/tweets.json";
    }
}