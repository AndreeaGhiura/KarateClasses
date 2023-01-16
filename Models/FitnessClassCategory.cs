using MessagePack;

namespace TrainingStudio02.Models
{
    public class FitnessClassCategory
    {
        public int ID { get; set; }
        public int FitnessClassID { get; set; }
        public FitnessClass FitnessClass { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
