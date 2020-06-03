using MRTwitter.Contracts;
using Newtonsoft.Json;
using System;

namespace MRTwitter
{
    [Serializable]
    public class TweetContract
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

       [JsonProperty("user")]
        public UserContract User { get; set; }
    }
}