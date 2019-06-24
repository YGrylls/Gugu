using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gugu.Model
{
    public class Party
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int party_id {get;set;}
        public string party_name { get; set; }
        public string party_desc { get; set; }
        public string party_aim { get; set; }
        public string party_type { get; set; }
        public int party_status { get; set; }
        public int party_num { get; set; }
        public int party_game { get; set; }
        public string party_connection { get; set; }
        public int party_longterm { get; set; }
        public int party_noob { get; set; }
        public DateTime pubtime { get; set; }
        public int current_num { get; set; }
        public Party()
        {

        }

    }
}
