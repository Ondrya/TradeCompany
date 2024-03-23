using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly DataService _context;

        public IndexModel(DataService context)
        {
            _context = context;
        }

        public IList<ClientDto> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = _context.ClientGetAll();
        }
    }
}
