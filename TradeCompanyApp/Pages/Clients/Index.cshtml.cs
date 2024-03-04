using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.Data;
using TradeCompanyApp.Models;

namespace TradeCompanyApp.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly TradeCompanyApp.Data.TradeCompanyAppContext _context;

        public IndexModel(TradeCompanyApp.Data.TradeCompanyAppContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Client != null)
            {
                Client = await _context.Client.ToListAsync();
            }
        }
    }
}
