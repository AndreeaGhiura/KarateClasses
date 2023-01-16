using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KarateClasses.Data;
using KarateClasses.Models;
using KarateClasses.Models.ViewModels;

namespace KarateClasses.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly KarateClasses.Data.KarateClassesContext _context;

        public IndexModel(KarateClasses.Data.KarateClassesContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int KarateID { get; set; }

        public async Task OnGetAsync(int? id, int? KarateClassID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.KarateCategories)
                .ThenInclude(c => c.Karate)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.Karate = category.KarateCategories.Select(fc => fc.Karate);
            }
        }
    }
}
