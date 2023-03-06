using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.Models
{
    public class DatabaseContext : DbContext
    {
        // table reference / handle
        public DbSet<Person> Person { get; set; }

        // hvis jeg glemmer denne, kommer der åbenbart ikke en tabel
        public DbSet<Car> Car { get; set; }
        public DbSet<Animal> Animal { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=TEC-8220-LA0025;" +
                "Initial Catalog=API001;Integrated Security=True");
        }
        //
        
        public DatabaseContext(){}
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {  }

    }
}
