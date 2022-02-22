using Kattalist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattalist.Infra.Data.Context
{
    public class KattalistDbContext : DbContext
    {
        public KattalistDbContext(DbContextOptions<KattalistDbContext> options) : 
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new GroceryListEntityTypeConfiguration().Configure(modelBuilder.Entity<GroceryList>());

            modelBuilder.Entity<GroceryList>()
                .ToTable("GroceryLists")
                .Property(p => p.Name).HasColumnType("varchar");
        }

        public DbSet<GroceryList> GroceryList { get; set; }
    }
}
