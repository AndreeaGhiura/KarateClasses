namespace KarateClasses.Models
{
    public class KarateData
    {
        public IEnumerable<Karate> Karate { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<KarateCategory> KarateCategories { get; set; }
    }
}
