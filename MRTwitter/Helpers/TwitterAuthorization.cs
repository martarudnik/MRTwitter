using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MRTwitter.Helpers
{
    public class TwitterAuthorization
    {
        private readonly Dictionary<string, string> Parameters;
        public string OAuthHeader
        {
            get { return CreateOAuthHeaderString();}
        }

        public string Query
        {
            get { return CreateQueryString(); }
        }

        public TwitterAuthorization(string fullUrl, Dictionary<string, string> parameters)
        {
            this.Parameters = CreateParameterDictionary(fullUrl, parameters);
        }
        public TwitterAuthorization()
        {
        }

        public string CreateSignature(string url, Dictionary<string, string> data)
        {
            var sigString = string.Join(
                "&",
                data
                    .Union(data)
                    .Select(kvp => string.Format("{0}={1}", 
                                   Uri.EscapeDataString(kvp.Key), 
                                   Uri.EscapeDataString(kvp.Value)))
                    .OrderBy(s => s)
            );

            var signatureBase = string.Format("{0}&{1}&{2}", "GET", Uri.EscapeDataString(url), Uri.EscapeDataString(sigString.ToString()));

            var signingKey = string.Format("{0}&{1}", ConfigurationManager.AppSettings["ConsumerSecret"], ConfigurationManager.AppSettings["AccessTokenSecret"]);

            return Uri.EscapeDataString(GetSha1Hash(signingKey, signatureBase));
        }

        public string GetSha1Hash(string key, string signatureBase)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string sha1Result;

            using (var sha1 = new HMACSHA1(encoding.GetBytes(key)))
            {
                var hashed = sha1.ComputeHash(encoding.GetBytes(signatureBase));
                sha1Result = Convert.ToBase64String(hashed);
            }

            return sha1Result;
        }

        public string CreateOAuthHeaderString()
        {
            return "OAuth " + string.Join(
                ", ",
                this.Parameters.OrderBy(kvp => kvp.Key)
                    .Where(kvp => kvp.Key.StartsWith("oauth_"))
                    .Select(kvp => string.Format("{0}=\"{1}\"", kvp.Key, kvp.Value))
            );
        }

        public string CreateQueryString()
        {
            return string.Join("&", this.Parameters
                .Where(kvp => !kvp.Key.StartsWith("oauth_"))
                .Select(kvp => string.Format("{0}={1}", kvp.Key, HttpUtility.UrlEncode(kvp.Value))));
        }
        public Dictionary<string, string> CreateParameterDictionary(string fullUrl, Dictionary<string, string> data)
        {
            var timestamp = (int)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);

            data.Add("oauth_consumer_key", ConfigurationManager.AppSettings["ConsumerKey"]);
            data.Add("oauth_nonce", Guid.NewGuid().ToString());
            data.Add("oauth_signature_method", ConfigurationManager.AppSettings["SignatureMethod"]);
            data.Add("oauth_timestamp", timestamp.ToString());
            data.Add("oauth_token", ConfigurationManager.AppSettings["AccessToken"]);
            data.Add("oauth_version", "1.0");
            data.Add("oauth_signature", CreateSignature(fullUrl, data));
            return data;
        }
    }
}