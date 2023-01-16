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
    public class CreateModel : PageModel
    {
        private readonly KarateClasses.Data.KarateClassesContext _context;

        public CreateModel(KarateClasses.Data.KarateClassesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var KarateClassList = _context.Karate
                .Include(b => b.Trainer)
                .Select(x => new
                {
                    x.ID,
                    FitnessClassFullName = x.Name + " - " + x.Trainer.FirstName + " "
                    + x.Trainer.LastName
                });

        ViewData["FitnessClassID"] = new SelectList(KarateClassList, "ID", "KarateClassFullName");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Subscription Subscription { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subscription.Add(Subscription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
