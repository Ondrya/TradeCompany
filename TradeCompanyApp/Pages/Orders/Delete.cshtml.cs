using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TradeCompanyApp.Domain.Models;
using TradeCompanyApp.Domain.Interfaces;

namespace TradeCompanyApp.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly IDataService _context;

        public DeleteModel(IDataService context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderDto Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var order = _context.OrderFind(id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var order = _context.OrderFind(id);

            _context.OrderRemove(order?.OrderId);

            return RedirectToPage("./Index");
        }
    }
}
