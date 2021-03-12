using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeatTreatment.Models;

namespace HeatTreatment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Grafik> GRAFIKLER { get; set; }
        public DbSet<Okuyucu> GRFOKUYUCU { get; set; }
        public DbSet<Nokta> GRFNOKTALAR { get; set; }
        
    }
}
