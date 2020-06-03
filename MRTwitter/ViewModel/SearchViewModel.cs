namespace MRTwitter.ViewModel
{
    public class SearchViewModel
    {
        public string Phrase { set; get; }
        public int PageNumber
        {
            get { return 1; }
        }
    }
}