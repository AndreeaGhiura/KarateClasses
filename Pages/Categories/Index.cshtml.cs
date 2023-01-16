using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingStudio02.Data;
using TrainingStudio02.Models;
using TrainingStudio02.Models.ViewModels;

namespace TrainingStudio02.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly TrainingStudio02.Data.TrainingStudio02Context _context;

        public IndexModel(TrainingStudio02.Data.TrainingStudio02Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int FitnessClassID { get; set; }

        public async Task OnGetAsync(int? id, int? fitnessClassID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.FitnessClassCategories)
                .ThenInclude(c => c.FitnessClass)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.FitnessClasses = category.FitnessClassCategories.Select(fc => fc.FitnessClass);
            }
        }
    }
}
