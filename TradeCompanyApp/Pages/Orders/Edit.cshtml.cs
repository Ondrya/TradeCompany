using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TradeCompanyApp.Domain.Models;
using TradeCompanyApp.Domain.Interfaces;

namespace TradeCompanyApp.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly IDataService _context;

        public EditModel(IDataService context)
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
            Order = order;
            ViewData["ClientId"] = new SelectList(_context.ClientGetAll(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderUpdate(Order);

            return RedirectToPage("./Index");
        }
    }
}
