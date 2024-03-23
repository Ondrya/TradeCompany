using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly DataService _context;

        public DetailsModel(DataService context)
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
