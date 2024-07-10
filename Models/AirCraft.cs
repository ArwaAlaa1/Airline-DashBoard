using AirLine.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AirLine.Models
{
    public class AirCraft:Entity<int>
    {

        [MaxLength(20)]
        public string Model { get; set; }

        public int Capacity { get; set; }
        public string  Major_Poilot { get; set; }
        public string Assistant_Pilot  { get; set; }
        public string Host1 { get; set; }
        public string Host2 { get; set; }
       
        public AirLine_Company AirLine { get; set; }
     
        public int  AirlineId { get; set; }


        public ICollection<Road_Craft> Craft_Roads { get; set; }


    }
}
