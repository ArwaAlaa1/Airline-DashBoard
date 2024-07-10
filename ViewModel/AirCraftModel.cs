using AirLine.Models;
using System.ComponentModel.DataAnnotations;

namespace AirLine.ViewModel
{
    public class AirCraftModel
    {

        [MaxLength(20)]
        public string Model { get; set; }

        public int Capacity { get; set; }
        public string Major_Poilot { get; set; }
        public string Assistant_Pilot { get; set; }
        public string Host1 { get; set; }
        public string Host2 { get; set; }

        public AirLine_Company AirLine { get; set; }

        public int AirlineId { get; set; }

        public List<AirLine_Company> AirLines { get; set; }
        public ICollection<Road_Craft> Craft_Roads { get; set; }

        public int Id { get; set; }
        public bool IsVisable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
