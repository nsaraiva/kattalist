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

        public DbSet<ListaCompras> ListaCompras { get; set; }
    }
}
