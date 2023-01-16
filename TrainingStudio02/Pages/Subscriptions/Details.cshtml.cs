using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KarateClasses.Data;
using KarateClasses.Models;

namespace KarateClasses.Pages.Subscriptions
{
    public class DetailsModel : PageModel
    {
        private readonly KarateClasses.Data.KarateClassesContext _context;

        public DetailsModel(KarateClasses.Data.KarateClassesContext context)
        {
            _context = context;
        }

      public Subscription Subscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription.FirstOrDefaultAsync(m => m.ID == id);
            if (subscription == null)
            {
                return NotFound();
            }
            else 
            {
                Subscription = subscription;
            }

            return Page();
        }
    }
}
