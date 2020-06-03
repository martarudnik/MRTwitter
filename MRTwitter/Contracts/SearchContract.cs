using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MRTwitter.Contracts
{
    [Serializable]
    public class SearchContract
    {
        [JsonProperty("statuses")]
        public List<TweetContract> Tweets { get; set; }
    }
}