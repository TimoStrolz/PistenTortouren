using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PistenTortouren
{
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Für autoincrement!
        public int tourID { get; set; }
        [Index]
        [Required]
        public int User_ID { get; set; }
        [Index]
        [Required, MaxLength(45)]
        public string title { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public string safetyInstruction { get; set; }
        [Required]
        public DateTime seasonStart { get; set; }
        [Required]
        public DateTime seasonEnd { get; set; }
        [Required]
        public float tourLength { get; set; }
        [Required]
        public int altitude { get; set; }
        [Required]
        public int lowestPoint { get; set; }
        [Required]
        public int highestPoint { get; set; }
        [Required]
        public float startingLongitude { get; set; }
        [Required]
        public float startingLatitude { get; set; }
        [Required]
        public float finishLongitude { get; set; }
        [Required]
        public float finishLatitude { get; set; }
        [Required]
        public string gettingThere { get; set; }
        [Required]
        public bool signalled { get; set; }
        [Required]
        public bool changingRooms { get; set; }
        [Required]
        public bool wc { get; set; }
        [Required]
        public bool drinks { get; set; }
        [Required]
        public bool food { get; set; }
        [Required]
        public bool accommodation { get; set; }
        [Index]
        [Required]
        public int status { get; set; }
        [Required]
        public string  instructions {get; set; }
        [Required]
        public DateTime birthday { get; set; }
        [Required]
        public int numberOfFiles { get; set; }
    }
}