using MRTwitter.Interfaces;
using MRTwitter.Validators;
using MRTwitter.ViewModel;
using System.Web.Mvc;

namespace MRTwitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITwitterService _twitterService;

        public HomeController(ITwitterService twitterService)
        {
            this._twitterService = twitterService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTweetByUserId()
        {
            var model = _twitterService.GetTweets();

            return PartialView("~/Views/Home/UserTweets.cshtml", model);
        }

        public ActionResult Search(string phrase)
        {
            var searchViewModel = new SearchResultsViewModel();
            searchViewModel.Errors = Validator.Text25LenghtValidator(phrase);
            if (searchViewModel.Errors.Count == 0)
            {
                searchViewModel= _twitterService.Search(phrase);
            }

            return PartialView("~/Views/Home/_Results.cshtml", searchViewModel);
        }
    }
}