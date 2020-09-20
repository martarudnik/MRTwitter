namespace MRTwitter.ViewModel
{
    public class SearchRequestViewModel
    {
        public string Phrase { set; get; }
        public int PageNumber
        {
            get { return 1; }
        }
    }
}