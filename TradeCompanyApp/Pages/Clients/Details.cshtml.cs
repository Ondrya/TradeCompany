using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly DataService _context;

        public DetailsModel(DataService context)
        {
            _context = context;
        }

      public ClientDto Client { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ClientDto client = _context.ClientGet(id);

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
    }
}
