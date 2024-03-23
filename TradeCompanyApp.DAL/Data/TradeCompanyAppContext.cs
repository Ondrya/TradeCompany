using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.DAL.Models;

namespace TradeCompanyApp.DAL.Data
{
    public class TradeCompanyAppContext : DbContext
    {
        public TradeCompanyAppContext(DbContextOptions<TradeCompanyAppContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } = default!;

        public DbSet<Order>? Order { get; set; }
    }
}
