using Microsoft.EntityFrameworkCore;

namespace TradeCompanyMVC.Models
{
    public class CrmContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public CrmContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
