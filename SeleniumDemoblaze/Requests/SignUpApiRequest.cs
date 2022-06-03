using SeleniumDemoblaze.Payload;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Requests
{
    public class SignUpApiRequest : ApiRequest
    {
        private static string _path = "/signup";

        public static string SignUpUser(User user)
        {
            return Post(_path, user);
        }
    }
}
