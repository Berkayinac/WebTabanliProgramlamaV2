using Microsoft.EntityFrameworkCore;
using MorningCoffee.Core.Entities.Concrete;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.DataAccess.Concrete.EntityFramework
{
    public class MorningCoffeeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MorningCoffee;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Frappuccino> Frappuccinos { get; set; }
        public DbSet<Tea> Teas { get; set; }
    }
}
