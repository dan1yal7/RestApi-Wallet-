using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectD.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace ProjectD
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
       
        public DbSet<Wallet> Wallets { get; set; }
      
        public DbSet<Transactions> Transactions { get; set; } 
        public DbSet<Balance> Balances { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Wallet");
        }


      
    }
}
