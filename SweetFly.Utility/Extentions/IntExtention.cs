using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Extentions
{
    public static class IntExtention
    {
        static Random _random = new Random();

        public static int GetRandom(this int max)
        {
            return _random.Next(max);
        }
    }
}
