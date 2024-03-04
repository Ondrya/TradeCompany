using Microsoft.EntityFrameworkCore;

namespace TradeCompany.DAL.Models
{
    public class CrmContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public CrmContext(DbContextOptions options) : base(options)
        {

        }
    }
}
