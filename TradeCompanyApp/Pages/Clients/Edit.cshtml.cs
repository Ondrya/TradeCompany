using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly DataService _context;

        public EditModel(DataService context)
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

            try
            {
                _context.Update(Client);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ClientExists(Client.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
