using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gugu.Common
{
    public class GetReq
    {
        public string type { get; set; }
        public int game { get; set; }
        public string aim { get; set; }
        public int page { get; set; }
        public GetReq()
        {

        }
        public bool validate()
        {
            if (game < 0 || game > 4) return false;
            if (type.Length > 8 ||aim.Length>8) return false;
            if (page < 0 || page > 100) return false;
            return true;
        }
    }
}
