using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TradeCompanyApp.Domain.Models;
using TradeCompanyApp.Domain.Interfaces;

namespace TradeCompanyApp.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly IDataService _context;

        public DetailsModel(IDataService context)
        {
            _context = context;
        }

      public OrderDto Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var order = _context.OrderGet(id);

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
