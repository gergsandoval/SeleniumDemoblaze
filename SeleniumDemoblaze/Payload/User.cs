using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Payload
{
    public class User
    {
        [JsonProperty("username")]
        private string _username;
        [JsonProperty("password")]
        private string _password;

        public User()
        {
            _username = Utils.RandomString();
            _password = Utils.RandomString();
        }

        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public string Username { get { return _username; } }
        public string Password { get { return _password; } }
    }
}
