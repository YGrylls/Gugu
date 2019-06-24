using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gugu.Common
{
    public class Result
    {
        public int code { get; set; }
        public string message { get; set; }
        public Object data { get; set; }
        public Result(int c, string m, Object d)
        {
            code = c;
            message = m;
            data = d;
        }
        public static Result successResult(string msg, Object o)
        {
            return new Result(0, msg, o);
        }
        public static Result failResult(string msg, Object o)
        {
            return new Result(1, msg, o);
        }
    }
}
