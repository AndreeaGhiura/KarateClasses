using Microsoft.AspNetCore.Mvc.RazorPages;
using KarateClasses.Data;

namespace KarateClasses.Models
{
    public class KarateCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(KarateClassesContext context,
            Karate karate)

        {

            var allCategories = context.Category;
            var karateCategories = new HashSet<int>(

            karate.KarateCategories.Select(c => c.CategoryID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = karateCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdatekarateCategories(KarateClassesContext context,
            string[] selectedCategories, Karate karateToUpdate)

        {

            if (selectedCategories == null)
            {
                karateToUpdate.KarateCategories = new List<KarateCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var karateCategories = new HashSet<int>
            (karateToUpdate.KarateCategories.Select(c => c.Category.ID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {

                    if (!karateCategories.Contains(cat.ID))
                    {
                        karateToUpdate.KarateCategories.Add(
                        new KarateCategory
                        {
                            KarateID = karateToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }

                else
                {
                    if (karateCategories.Contains(cat.ID))
                    {

                        KarateCategory courseToRemove = karateToUpdate.KarateCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);

                    }
                }
            }
        }
    }
}
