﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PistenTortouren.Datenklassen
{
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Für autoincrement!
        public int eventID { get; set; }
        [Index]
        [Required]
        public int Tours_ID { get; set; }
        [Required]
        public string info { get; set; }
        [Index]
        [Required]
        public DateTime start { get; set; }
        [Required]
        public DateTime finish { get; set; }
        [Required]
        public string inscription { get; set; }
    }
}