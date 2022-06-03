using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumDemoblaze
{
    public class Utils
    {
        public static string RandomString()
        {
            return Path.GetRandomFileName().Replace(".", String.Empty);
        }
    }
}
