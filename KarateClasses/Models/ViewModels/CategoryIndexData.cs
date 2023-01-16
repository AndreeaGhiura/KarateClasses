namespace KarateClasses.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Karate> Karate { get; set; }
    }
}
