using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gugu.Model;

namespace Gugu.Model
{
    public class PartyInfo
    {
        public Party party { get; set; }
        public List<string> mems { get; set; }
        public PartyInfo()
        {

        }
    }
}
