using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly DataService _context;

        public DeleteModel(DataService context)
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
