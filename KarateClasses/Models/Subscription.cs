using System.ComponentModel.DataAnnotations;

namespace KarateClasses.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? KarateID { get; set; }
        public Karate? Karate { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }
    }
}
