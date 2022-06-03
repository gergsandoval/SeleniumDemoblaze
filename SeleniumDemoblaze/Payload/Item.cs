using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Payload
{
    public class Item
    {
        [JsonProperty("cookie")]
        private string _token;
        [JsonProperty("flag")]
        private Boolean _flag;
        [JsonProperty("id")]
        private string _id;
        [JsonProperty("prod_id")]
        private int _productId;
        public Item(string cookie, string id, int productId)
        {
            _token = cookie;
            _flag = true;
            _id = id;
            _productId = productId;
        }
    }


}
