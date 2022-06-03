using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SeleniumDemoblaze.Payload;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SeleniumDemoblaze.Requests
{
    public class LoginApiRequest : ApiRequest
    {
        private static string _path = "/login";
        private static string _authTokenKey = "Auth_token: ";

        public static string LoginUser(User user)
        {
            var result = Post(_path, user);
            return result.Replace(_authTokenKey, String.Empty).Trim().Trim('"');
        }
    }
}
