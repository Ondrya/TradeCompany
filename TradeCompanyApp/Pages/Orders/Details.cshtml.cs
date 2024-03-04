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
    public class DetailsModel : PageModel
    {
        private readonly TradeCompanyApp.Data.TradeCompanyAppContext _context;

        public DetailsModel(TradeCompanyApp.Data.TradeCompanyAppContext context)
        {
            _context = context;
        }

      public Order Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context
                .Order
                .Where(m => m.OrderId == id)
                .Include(x => x.Client)
                .FirstOrDefaultAsync();


            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }
    }
}
