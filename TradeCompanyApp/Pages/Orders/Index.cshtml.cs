using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.Data;
using TradeCompanyApp.Models;

namespace TradeCompanyApp.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly TradeCompanyApp.Data.TradeCompanyAppContext _context;

        public IndexModel(TradeCompanyApp.Data.TradeCompanyAppContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                Order = await _context.Order
                .Include(o => o.Client).ToListAsync();
            }
        }
    }
}
