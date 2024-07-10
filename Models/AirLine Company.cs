using AirLine.Entity;
using System.ComponentModel.DataAnnotations;

namespace AirLine.Models
{
    public class AirLine_Company: Entity<int>
    {
        
            [MaxLength(20)]
            public string Name { get; set; }
            public string Contact_Name { get; set; }
            public string? Address { get; set; }

           public ICollection<Transaction> Transactions { get; set; }
           public ICollection<AirCraft> AirCrafts { get; set; }


    }
}
