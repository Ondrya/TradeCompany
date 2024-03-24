using Microsoft.AspNetCore.Mvc.RazorPages;
using TradeCompanyApp.Domain.Models;
using TradeCompanyApp.Domain.Interfaces;

namespace TradeCompanyApp.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _context;

        public IndexModel(IDataService context)
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
