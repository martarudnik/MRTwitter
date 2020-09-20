using MRTwitter.Constants;
using MRTwitter.Interfaces;
using MRTwitter.Validators;
using MRTwitter.ViewModel;
using System.Web.Mvc;

namespace MRTwitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITwitterService _twitterService;
        private readonly ICacheService _cacheService;

        public HomeController(ITwitterService twitterService, ICacheService cacheService)
        {
            this._twitterService = twitterService;
            this._cacheService = cacheService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTweetByUserId()
        {
            var model = _cacheService.GetOrSet(TwitterParameterKey.UserFeed, () => _twitterService.GetTweets());


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