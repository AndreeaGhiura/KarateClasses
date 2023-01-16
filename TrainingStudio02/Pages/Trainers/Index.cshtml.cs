using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KarateClasses.Data;
using KarateClasses.Models;
using KarateClasses.Models.ViewModels;

namespace KarateClasses.Pages.Trainers
{
    public class IndexModel : PageModel
    {
        private readonly KarateClasses.Data.KarateClassesContext _context;

        public IndexModel(KarateClasses.Data.KarateClassesContext context)
        {
            _context = context;
        }

        public IList<Trainer> Trainer { get;set; } = default!;

        public TrainerIndexData TrainerData { get; set; }
        public int TrainerID { get; set; }
        public int KarateClassID { get; set; }
        public async Task OnGetAsync(int? id, int? KarateClassesID)
        {
            TrainerData = new TrainerIndexData();
            TrainerData.Trainers = await _context.Trainer
                .Include(i => i.Karate)
                .ThenInclude(c => c.Location)
                .OrderBy(i => i.LastName) //Nu poti face referinta dupa Full Name pentru ca nu e in baza de date
                .ToListAsync();
            if (id != null)
            {
                TrainerID = id.Value;
                Trainer trainer = TrainerData.Trainers
                    .Where(i => i.ID == id.Value).Single();
                TrainerData.Karate = trainer.Karate;
            }
        }
    }
}
