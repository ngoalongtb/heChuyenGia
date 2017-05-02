using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon
{
    public static class Global
    {
        public static Expert GExpert = null;
        public static int GViTriCau = 1;
        public static string GAnswer = "";

        public static void Reset()
        {
            Global.GAnswer = "";
            Global.GViTriCau = 1;
        }
    }
}
