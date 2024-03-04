using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.Models;

namespace TradeCompanyApp.Data
{
    public class TradeCompanyAppContext : DbContext
    {
        public TradeCompanyAppContext (DbContextOptions<TradeCompanyAppContext> options)
            : base(options)
        {
        }

        public DbSet<TradeCompanyApp.Models.Client> Client { get; set; } = default!;

        public DbSet<TradeCompanyApp.Models.Order>? Order { get; set; }
    }
}
