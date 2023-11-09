using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Helper
{
    public class TimeHelper
    {
        public static DateTime GetDateTime()
        {
            var time = DateTime.UtcNow;
            time = time.AddHours(5);

            return time;
        }
    }
}
