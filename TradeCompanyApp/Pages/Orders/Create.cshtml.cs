using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TradeCompanyApp.Domain.Models;
using TradeCompanyApp.Domain.Interfaces;

namespace TradeCompanyApp.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IDataService _context;

        public CreateModel(IDataService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(_context.ClientGetAll(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public OrderDto Order { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderCreate(Order);

            return RedirectToPage("./Index");
        }
    }
}
