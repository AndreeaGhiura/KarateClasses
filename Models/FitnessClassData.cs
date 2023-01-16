namespace TrainingStudio02.Models
{
    public class FitnessClassData
    {
        public IEnumerable<FitnessClass> FitnessClasses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FitnessClassCategory> FitnessClassCategories { get; set; }
    }
}
