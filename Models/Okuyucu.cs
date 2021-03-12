using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeatTreatment.Models
{
    public class Okuyucu
    {
        [Key, Required]
        public int ID { get; set; }
        [Required]
        public string GRUP { get; set; }
        [Required]
        public string OKUYUCUADI { get; set; }
        [Required]
        public double ARTI { get; set; }
        [Required]
        public double EKSI { get; set; }
    }
}
