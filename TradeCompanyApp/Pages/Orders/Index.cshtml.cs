using Microsoft.AspNetCore.Mvc.RazorPages;
using TradeCompanyApp.Domain.Models;
using TradeCompanyApp.Domain.Interfaces;

namespace TradeCompanyApp.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _context;

        public IndexModel(IDataService context)
        {
            _context = context;
        }

        public IList<OrderDto> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = _context.OrderGetAll();
        }
    }
}
