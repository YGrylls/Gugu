using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gugu.Common
{
    public class PublishReq
    {
        public string title { get; set; }
        public string desc { get; set; }
        public string aim { get; set; }
        public string type { get; set; }
        public int num { get; set; }
        public int game { get; set; }
        public string connection { get; set; }
        public bool longterm { get; set; }
        public bool noob { get; set; }
        public PublishReq()
        {

        }
        public bool validate()
        {
            if (title.Length > 60) return false;
            if (desc.Length > 140) return false;
            if (connection.Length > 60) return false;
            if (num < 2 || num > 10) return false;
            if (game < 0 || game > 4) return false;
            return true;
        }
    }
}
