using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Clients
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
            return Page();
        }

        [BindProperty]
        public ClientDto Client { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Client == null)
            {
                return Page();
            }

            _context.Create(Client);
            
            return RedirectToPage("./Index");
        }
    }
}
