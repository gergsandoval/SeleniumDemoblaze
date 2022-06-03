using SeleniumDemoblaze.Payload;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Requests
{
    public class AddToCartApiRequest : ApiRequest
    {
        private static string _path = "/addtocart";
        public static string AddToCart(Item item)
        {
            return Post(_path, item);
        }
    }
}
