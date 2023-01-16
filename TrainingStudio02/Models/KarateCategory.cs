using MessagePack;

namespace KarateClasses.Models
{
    public class KarateCategory
    {
        public int ID { get; set; }
        public int KarateID { get; set; }
        public Karate Karate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
