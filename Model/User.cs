
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gugu.Model
{
    [SerializableAttribute]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}