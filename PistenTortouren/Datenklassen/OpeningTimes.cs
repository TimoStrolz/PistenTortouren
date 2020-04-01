using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PistenTortouren
{
    public class OpeningTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Für autoincrement!
        public int openingTimeID { get; set; }
        [Required]
        public int Tour_ID { get; set; }
        [Required, MaxLength(20)]
        public string day { get; set; }
        [Required]
        public DateTime start { get; set; }
        [Required]
        public DateTime end { get; set; }


    }
}