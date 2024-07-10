using AirLine.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLine.Models
{
    public class Road:Entity<int>
    {
        // rout_id/ origin/distination /distance/ classification

       
        public string Origin { get; set; }
        public string Distination { get; set; }
        public double Distance { get; set; }

        public string  Classification { get; set; }

        public ICollection<Road_Craft> Road_Crafts { get; set; } 
    }
}
