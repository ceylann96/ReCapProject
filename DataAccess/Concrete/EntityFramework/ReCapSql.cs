using Core.Entities.Concrete;
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
            public DbSet<Customer> Customerss { get; set; }
            public DbSet<Rental> Rentalss { get; set; }
            public DbSet<CarImage> CarImagess{ get; set; }

            // CORE KATMANI ENTİTiES
            public DbSet<OperationClaim> OperationClaimss { get; set; }
            public DbSet<User> Userss { get; set; }
            public DbSet<UserOperationClaim> UserOperationClaimss { get; set; }




    }
 }

