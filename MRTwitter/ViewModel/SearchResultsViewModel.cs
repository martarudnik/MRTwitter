using System.Collections.Generic;

namespace MRTwitter.ViewModel
{
    public class SearchResultsViewModel : BaseViewModel
    {
        public List<TweetViewModel> Tweets { get; set; }
    }
}