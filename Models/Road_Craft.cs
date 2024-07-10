using AirLine.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLine.Models
{
    public class Road_Craft:Entity<int>
    {
        //route_id /craft_id/departure/ price/ num_of_passenger/ arrival
        //duration derived

        public int RouteId { get; set; }
        public int AirCraftId { get; set; }

        [DataType(DataType.Time)]
        public DateTime DepatureTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }

        [Column(TypeName ="money")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int NumPassenger { get; set; }

        ////not must navigational property
        //public Road Road { get; set; }
        //public AirCraft AirCraft { get; set; }

    }
}
