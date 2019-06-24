using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gugu.Model
{
    public class PartyMem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int r_id { get; set; }
        public int party_id { get; set; }
        public int user_id { get; set; }
        public int is_leader { get; set; }
    }
}
