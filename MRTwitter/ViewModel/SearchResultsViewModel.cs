using System.Collections.Generic;

namespace MRTwitter.ViewModel
{
    public class SearchResultsViewModel : ValidationViewModel
    {
        public List<TweetViewModel> Tweets { get; set; }
    }
}