using MRTwitter.ViewModel;
using System.Collections.Generic;

namespace MRTwitter.Interfaces
{
    public interface ITwitterService
    {
        List<TweetViewModel> GetTweet();
    }
}