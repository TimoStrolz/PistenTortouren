using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PistenTortouren.Datenklassen
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Für autoincrement!
        public int userID { get; set; }
        [Required, MaxLength(64)]
        public string name { get; set; }
        [Required, MaxLength(128)]
        public string website { get; set; }
        [Required, MaxLength(12)]
        public string phone { get; set; }
        [Index]
        [Required, MaxLength(64)]
        public string password { get; set; }
        [Index]
        [Required, MaxLength(50)]
        public string email { get; set; }
        [Required]
        public DateTime lastPayment { get; set; }
        [Required]
        public bool emailVerified { get; set; }
        [Required]
        public DateTime billSent { get; set; }
        [Required]
        public DateTime birthday { get; set; }
        [Index]
        [Required, MaxLength(45)]
        public string language { get; set; }
        [Required, MaxLength(45)]
        public string country { get; set; }
        [Required, MaxLength(45)]
        public string city { get; set; }
        [Required, MaxLength(45)]
        public string street { get; set; }
        [Required]
        public int zip { get; set; }
        [Required]
        public int housenumber { get; set; }
        [Required]
        public int subscriptionnumber { get; set; }
    }
}