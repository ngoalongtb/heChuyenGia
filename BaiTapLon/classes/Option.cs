using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon.classes
{
    public class Option
    {
        private string index;
        private string content;


        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public string Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }
    }
}
