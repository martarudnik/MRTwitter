using MRTwitter.Interfaces;
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
            var model = _twitterService.GetTweet();

            return PartialView("~/Views/Home/UserTweets.cshtml", model);
        }

        public ActionResult Search(string phrase)
        {
            //if (searchViewModel.Errors.Count > 0)
            //{
            //    return PartialView("~/Views/Home/_Results.cshtml", searchViewModel);
            //}

            var searchViewModel = _twitterService.Search(phrase);

            //var tweetIds = searchViewModel.Tweets.Select(x => x.Id);



            return PartialView("~/Views/Home/_Results.cshtml", searchViewModel);
        }
    }
}