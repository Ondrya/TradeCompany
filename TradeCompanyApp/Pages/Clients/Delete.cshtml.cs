using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly DataService _context;

        public DeleteModel(DataService context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            _context.ClientRemove(id.Value);


            return RedirectToPage("./Index");
        }
    }
}
