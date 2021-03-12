using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeatTreatment.Models
{
    public class Grafik
    {
        [Key, Required]
        public int ID { get; set; }
        [Required]
        public string GRAFIKADI { get; set; }
        [Required]
        public TimeSpan ZAMANARALIK { get; set; }
        [Required]
        public DateTime BASLAMA { get; set; }
    }
}
