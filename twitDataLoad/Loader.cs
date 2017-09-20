using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Tweetinvi;
//using Tweetinvi.Models;
//using Tweetinvi.Credentials;
using System.Net.Http;
using System.Net;
using System.IO;
using twitDataModel;

namespace twitDataLoad
{
    public class Loader
    {
        public string Authentificate()
        {
            //string access_token = "909380327956676609-kdNj948SFAGv0uI6YVTB0ldnuccX5yH";
            //string access_token_secret = "2Mmn5ud70jGQVyN4h3Puew1yzGYqskuzQo3MGAqpkdnLA";
            //string cons_key = "9eTJLyDqpUdY78Lu9QKzn03bs";
            //string cons_secret = "ZgjxeVbB8ApBxEuUamrUO4LGSlYcI6Qg4ttGGnKNEEIL5L70Gm";

            //// Auth.SetUserCredentials(cons_key, cons_secret, access_token, access_token_secret);

            //ITwitterCredentials creds = new TwitterCredentials(cons_key, cons_secret, access_token, access_token_secret);
            //Auth.SetUserCredentials(cons_key, cons_secret, access_token, access_token_secret);
            //  TwitterCredentials.SetCredentials(access_token, access_token_secret, cons_key, cons_secret);


            var oAuthConsumerKey = "9eTJLyDqpUdY78Lu9QKzn03bs";
            var oAuthConsumerSecret = "ZgjxeVbB8ApBxEuUamrUO4LGSlYcI6Qg4ttGGnKNEEIL5L70Gm";
            var oAuthUrl = "https://api.twitter.com/oauth2/token";
            var screenname = "iamlaba1";

            var authHeaderFormat = "Basic {0}";

            var authHeader = string.Format(authHeaderFormat,
    Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oAuthConsumerKey) + ":" +
    Uri.EscapeDataString((oAuthConsumerSecret)))
));
            var postBody = "grant_type=client_credentials";

            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
            authRequest.Headers.Add("Authorization", authHeader);
            authRequest.Method = "POST";
            authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (Stream stream = authRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }

            authRequest.Headers.Add("Accept-Encoding", "gzip");

            WebResponse authResponse = authRequest.GetResponse();

            TwitAuthenticateResponse twitAuthResponse;
            using (authResponse)
            {
                using (var reader = new StreamReader(authResponse.GetResponseStream()))
                {
                    var objectText = reader.ReadToEnd();
                    dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(objectText);
                    twitAuthResponse = new TwitAuthenticateResponse() { access_token = x.access_token, token_type = x.token_type };
                }
            }


            var timelineFormat = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&include_rts=1&exclude_replies=1&count=5";
            var timelineUrl = string.Format(timelineFormat, screenname);
            HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(timelineUrl);
            var timelineHeaderFormat = "{0} {1}";
            timeLineRequest.Headers.Add("Authorization", string.Format(timelineHeaderFormat, twitAuthResponse.token_type, twitAuthResponse.access_token));
            timeLineRequest.Method = "Get";
            WebResponse timeLineResponse = timeLineRequest.GetResponse();
            var timeLineJson = string.Empty;
            using (timeLineResponse)
            {
                using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                {
                    timeLineJson = reader.ReadToEnd();
                }
            }
            return timeLineJson.ToString();
        }

        public string SearchTweets(string search)
        {
            
            string s;
            string username= Authentificate();
            //char[] c = search.ToCharArray();
            //if(c[0]=='@')
            //{
            //    s = search;
            //}
            //else
            //{
            //    s = "@" + search;
            //}
            //var user = User.GetUserFromScreenName(s);

            //
            //if (user==null)
            //{
            //    username = "Неудалось найти пользователя";
            //}
            //else
            //{
            //    username = user.Name;
            //}

            return username;
        }
    }
}
