using MRTwitter.ViewModel;

namespace MRTwitter.Interfaces
{
    public interface ITwitterService
    {
        UserTweetsViewModel GetTweets();
        SearchResultsViewModel Search(string phrase);
    }
}