using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core;
using Tweetinvi.Models;
using Tweetinvi.WebLogic;
//using Tweetinvi.

namespace twDataModel
{
    class Load
    {
    }


    public class TwitterAuth
    {
        public void Authen()
        {
            var access_token = "909380327956676609-kdNj948SFAGv0uI6YVTB0ldnuccX5yH";
            var access_token_secret = "2Mmn5ud70jGQVyN4h3Puew1yzGYqskuzQo3MGAqpkdnLA";
            var cons_key = "jiKV4IJ4sEVQsgxasuLfzuKsU";
            var cons_secret = "UohvcUCjw3FYiCUmmUeXgx9eXE02S81Iv5lqoTYIQhqMVV7UYc";

            ITwitterCredentials creds = new TwitterCredentials(access_token, access_token_secret, cons_key, cons_secret);

            Auth.SetCredentials(creds);

        }
    }
}
