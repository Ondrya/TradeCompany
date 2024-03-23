using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.ModelsDto;
using TradeCompanyApp.Services;

namespace TradeCompanyApp.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly DataService _context;

        public IndexModel(DataService context)
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
