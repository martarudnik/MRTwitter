using Newtonsoft.Json;
using System;

namespace MRTwitter.Contracts
{
    [Serializable]
    public class UserContract
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}