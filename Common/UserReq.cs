using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gugu.Common
{
    public class UserReq
    {
        public string username { get; set; }
        public string password { get; set; }
        public UserReq()
        {

        }
        public bool validate()
        {
            string pattern = "^[0-9a-zA-Z_]+$";
            Regex regex = new Regex(pattern);
            bool format = regex.IsMatch(username) && regex.IsMatch(password);
            return (username.Length <= 16 && password.Length <= 16 && format);
        }
    }
}
