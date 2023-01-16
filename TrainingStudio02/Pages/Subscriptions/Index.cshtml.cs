using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KarateClasses.Data;
using KarateClasses.Models;

namespace KarateClasses.Pages.Subscriptions
{
    public class IndexModel : PageModel
    {
        private readonly KarateClasses.Data.KarateClassesContext _context;

        public IndexModel(KarateClasses.Data.KarateClassesContext context)
        {
            _context = context;
        }

        public IList<Subscription> Subscription { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subscription != null)
            {
                Subscription = await _context.Subscription
                .Include(s => s.Karate)
                .ThenInclude(b => b.Trainer)
                .Include(s => s.Member).ToListAsync();
            }
        }
    }
}
