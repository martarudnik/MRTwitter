using AutoMapper;
using MRTwitter.Constants;
using MRTwitter.Contracts;
using MRTwitter.Helpers;
using MRTwitter.Interfaces;
using MRTwitter.Utilities;
using MRTwitter.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace MRTwitter.Services
{
    public class TwitterService : ITwitterService
    {
        public UserTweetsViewModel GetTweets()
        {
            var data = new Dictionary<string, string>
            {
                { TwitterParameterKey.UserId, ConfigurationManager.AppSettings["UserId"] },
                { TwitterParameterKey.Count, TwitterParameterKey.TweeterCount5 }
            };

            var twitterAutorization = new TwitterAuthorization(TwitterEndpointUrlConstants.GetStatutes, data);

            var response = SendToRequestToTwitter(TwitterEndpointUrlConstants.GetStatutes, twitterAutorization.OAuthHeader, twitterAutorization.Query);
            if (response == null)
            {
                Log.Warn("[TwitterService][GetTweet] - SendToRequestToTwitter response is null");
                return null;
            }

            var deserializedData = (List<TweetContract>)JsonConvert.DeserializeObject(response, typeof(List<TweetContract>));

            if (deserializedData == null)
            {
                Log.Warn("[TwitterService][GetTweet] - Deserialize object is null");
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TweetContract, TweetViewModel>();
                cfg.CreateMap<UserContract, UserViewModel>();
            });

            var tweets = config.CreateMapper().Map<List<TweetContract>, List<TweetViewModel>>(deserializedData);

            return new UserTweetsViewModel { UsersTweets = tweets };
        }


        public SearchResultsViewModel Search(string phrase)
        {
            var data = new Dictionary<string, string>
            {
                { TwitterParameterKey.Query, phrase },
                { TwitterParameterKey.Count, "10" }
            };

            var twitterAutorization = new TwitterAuthorization(TwitterEndpointUrlConstants.GetSearchTweets, data);

            var repsonse = SendToRequestToTwitter(TwitterEndpointUrlConstants.GetSearchTweets, twitterAutorization.OAuthHeader, twitterAutorization.Query);

            var model = new SearchRequestViewModel();

            if (repsonse == null)
            {
                Log.Warn("[TwitterService][Search] - SendToRequestToTwitter response is null");
            }

            var deserializedData = JsonConvert.DeserializeObject<SearchContract>(repsonse);
            if (deserializedData == null)
            {
                Log.Warn("[TwitterService][Search] - deserialize object is null");
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SearchContract, SearchResultsViewModel>();
                cfg.CreateMap<TweetContract, TweetViewModel>();
                cfg.CreateMap<UserContract, UserViewModel>();
            });

            var mapper = config.CreateMapper();

            var searchResultsViewModel = mapper.Map<SearchContract, SearchResultsViewModel>(deserializedData);
            return searchResultsViewModel;
        }

        private string SendToRequestToTwitter(string fullUrl, string oAuthHeader, string query)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var uriBuilder = new UriBuilder(new Uri(fullUrl, UriKind.Absolute))
                    {
                        Query = query.ToString()
                    };

                    httpClient.DefaultRequestHeaders.Add("Authorization", oAuthHeader);

                    var httpResponse = httpClient.GetAsync(uriBuilder.ToString()).Result;

                    if (httpResponse == null)
                    {
                        Log.Warn("[TwitterService][Search] - httpResponse is null");
                    }

                    var response = httpResponse.Content.ReadAsStringAsync().Result;

                    return response;
                }
            }
            catch
            {
                Log.Error("[TwitterService][SendToRequestToTwitter]- problem with send request to twitter ");
                return null;
            }
        }
    }
}