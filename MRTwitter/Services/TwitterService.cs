using AutoMapper;
using MRTwitter.Constants;
using MRTwitter.Contracts;
using MRTwitter.Helpers;
using MRTwitter.Interfaces;
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
        public List<TweetViewModel> GetTweet()
        {
            var data = new Dictionary<string, string>
            {
                { TwitterParameterKey.UserId, ConfigurationManager.AppSettings["UserId"] },
                { TwitterParameterKey.Count, TwitterParameterKey.TweeterCount5 }
            };

            var twitterAutorization = new TwitterAuthorization(TwitterEndpointUrlConstants.GetStatutes, data);

            var response = SendToRequestToTwitter(TwitterEndpointUrlConstants.GetStatutes, twitterAutorization.OAuthHeader, twitterAutorization.Query);
            if (response == null) return null;
            {
                //errors
            }

            var deserializedData = (List<TweetContract>)JsonConvert.DeserializeObject(response, typeof(List<TweetContract>));

            if (deserializedData == null)
            {
                //errors
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TweetContract, TweetViewModel>();
                cfg.CreateMap<UserContract, UserViewModel>();
            });

            var mapper = config.CreateMapper();

            var tweetViewModel = mapper.Map<List<TweetContract>, List<TweetViewModel>>(deserializedData);
            return tweetViewModel;
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

            var model = new SearchViewModel();

            if (repsonse == null)
            {
               //errors
            }

            var deserializedData = JsonConvert.DeserializeObject<SearchContract>(repsonse);
            if (deserializedData == null)
            {
               //errors
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
                    var response = httpResponse.Content.ReadAsStringAsync().Result;

                    return response;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}