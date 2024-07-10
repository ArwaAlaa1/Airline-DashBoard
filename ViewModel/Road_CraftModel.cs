using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AirLine.Models;

namespace AirLine.ViewModel
{
    public class Road_CraftModel
    { 

        public int RouteId { get; set; }
        public int AirCraftId { get; set; }

        [DataType(DataType.Time)]
        public DateTime DepatureTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }

        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int NumPassenger { get; set; }

        public List<AirCraft> AirCRS { get; set; }
        public List<Road> RDs { get; set; }
        public bool IsVisable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
