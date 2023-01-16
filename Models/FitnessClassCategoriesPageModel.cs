using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingStudio02.Data;

namespace TrainingStudio02.Models
{
    public class FitnessClassCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(TrainingStudio02Context context,
            FitnessClass fitnessClass)

        {

            var allCategories = context.Category;
            var fitnessClassCategories = new HashSet<int>(

            fitnessClass.FitnessClassCategories.Select(c => c.CategoryID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = fitnessClassCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateFitnessClassCategories(TrainingStudio02Context context,
            string[] selectedCategories, FitnessClass fitnessClassToUpdate)

        {

            if (selectedCategories == null)
            {
                fitnessClassToUpdate.FitnessClassCategories = new List<FitnessClassCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var fitnessClassCategories = new HashSet<int>
            (fitnessClassToUpdate.FitnessClassCategories.Select(c => c.Category.ID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {

                    if (!fitnessClassCategories.Contains(cat.ID))
                    {
                        fitnessClassToUpdate.FitnessClassCategories.Add(
                        new FitnessClassCategory
                        {
                            FitnessClassID = fitnessClassToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }

                else
                {
                    if (fitnessClassCategories.Contains(cat.ID))
                    {

                        FitnessClassCategory courseToRemove = fitnessClassToUpdate.FitnessClassCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);

                    }
                }
            }
        }
    }
}
