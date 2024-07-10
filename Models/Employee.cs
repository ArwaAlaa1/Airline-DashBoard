using AirLine.Entity;
using System.ComponentModel.DataAnnotations;

namespace AirLine.Models
{
    public class Employee : Entity<int>
    {
        [MaxLength(20)]
        public string Name { get; set; }

        public string? Address { get; set; }

        public DateTime BDDay { get; set; }
        public DateTime BDMonth { get; set; }
        public DateTime BDYear { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }

        public AirLine_Company airLine { get; set; }
        public int AirLineId { get; set; }

    }
}
