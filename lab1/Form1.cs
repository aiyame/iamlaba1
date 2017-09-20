using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using twitDataLoad;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Credentials;
using System.Net.Http;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string access_token = "909380327956676609-kdNj948SFAGv0uI6YVTB0ldnuccX5yH";
            //string access_token_secret = "2Mmn5ud70jGQVyN4h3Puew1yzGYqskuzQo3MGAqpkdnLA";
            //string cons_key = "9eTJLyDqpUdY78Lu9QKzn03bs";
            //string cons_secret = "ZgjxeVbB8ApBxEuUamrUO4LGSlYcI6Qg4ttGGnKNEEIL5L70Gm";

            // Auth.SetUserCredentials(cons_key, cons_secret, access_token, access_token_secret);

            //ITwitterCredentials creds = new TwitterCredentials(cons_key, cons_secret, access_token, access_token_secret);
            //Auth.SetUserCredentials(cons_key, cons_secret, access_token, access_token_secret);

            Loader L = new Loader();
            L.Authentificate();
            textBox2.Text = L.SearchTweets(textBox1.Text);

          //  var user = User.GetUserFromScreenName("@"+textBox1.Text);
          //  string sss = user.Name;
           
         //   textBox2.Text = sss;

        }
    }
}
