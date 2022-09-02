using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapSql : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database=ReCapProject; Trusted_Connection=true");
        }

            public DbSet<Car> Carss { get; set; }
            public DbSet<Brand> Brandss { get; set; }
            public DbSet<Color> Colorss { get; set; }
    }
 }

