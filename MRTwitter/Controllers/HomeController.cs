﻿using MRTwitter.Interfaces;
using System.Web.Mvc;

namespace MRTwitter.Controllers
{
    public class HomeController : Controller{
        private readonly ITwitterService _twitterService;
    
        public HomeController(ITwitterService twitterService)
        {
            this._twitterService = twitterService;
        }

        public ActionResult Index()
        {
            _twitterService.GetTweet();
            return View();
        }
    }
}