using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly DataService _context;

        public CreateModel(DataService context)
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

            _context.Create(Order);

            return RedirectToPage("./Index");
        }
    }
}
