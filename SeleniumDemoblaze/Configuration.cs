using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze
{
    public class Configuration
    {
        private static string tokenCookieKey => "tokenp_";
        private static string baseUrl => "https://www.demoblaze.com";
        private static string baseEndpoint => "https://api.demoblaze.com";
        private static Double timeout => 10;

        public static string TokenCookieKey { get { return tokenCookieKey; } }
        public static string BaseUrl { get { return baseUrl; } }
        public static string BaseEndpoint { get { return baseEndpoint;  } }
        public static Double Timeout { get { return timeout; } }

    }
}
