using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace yshakova_7
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AirFlow> airflow => Set<AirFlow>();
        public DbSet<Volume> volume => Set<Volume>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=avemelissa;Database=hotelIsk");
        }
    }
}
