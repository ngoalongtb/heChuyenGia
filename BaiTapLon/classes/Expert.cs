using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon
{
    public class Expert
    {

        private string name;
        private string image;
        private string createBy;
        private string info;
        private string path;


        public Expert()
        {
            this.Name = "";
            this.Image = "";
            this.CreateBy = "";
            this.Info = "";
            this.Path = "";
        }

        public Expert(string name, string path, string image, string createBy, string info)
        {
            this.Name = name;
            this.Image = image;
            this.CreateBy = createBy;
            this.Info = info;
            this.Path = path;
        }

        public string Info
        {
            get
            {
                return info;
            }

            set
            {
                info = value;
            }
        }

        public string CreateBy
        {
            get
            {
                return createBy;
            }

            set
            {
                createBy = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }
    }
}
