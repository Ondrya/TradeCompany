﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TradeCompanyMVC.Models;

namespace TradeCompanyMVC.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly TradeCompanyMVC.Models.CrmContext _context;

        public IndexModel(TradeCompanyMVC.Models.CrmContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Clients != null)
            {
                Client = await _context.Clients.ToListAsync();
            }
        }
    }
}
