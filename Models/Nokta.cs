using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeatTreatment.Models
{
    public class Nokta
    {
        [Key, Required]
        public int ID { get; set; }
        [Required]
        public int GRAFIKID { get; set; }
        [Required]
        public double BASLAMASICAKLIK { get; set; }
        [Required]
        public double BITISSICAKLIK { get; set; }
        [Required]
        public TimeSpan BEKLEMESURESI { get; set; }
        [Required]
        public double HIZI { get; set; }
        [Required]
        public int SIRANO { get; set; }
        [Required]
        public double ARTI { get; set; }
        [Required]
        public double EKSI { get; set; }
    }
}
