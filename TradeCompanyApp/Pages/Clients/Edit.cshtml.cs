using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TradeCompanyApp.Domain.Models;
using TradeCompanyApp.Domain.Interfaces;

namespace TradeCompanyApp.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly IDataService _context;

        public EditModel(IDataService context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientDto Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var client = _context.ClientFind(id);

            if (client == null)
            {
                return NotFound();
            }
            else
            {
                Client = client;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Update(Client);

            return RedirectToPage("./Index");
        }
    }
}
