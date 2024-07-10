using AirLine.Models;

namespace AirLine.ViewModel
{
    public class RoadModel
    {


        public string Origin { get; set; }
        public string Distination { get; set; }
        public double Distance { get; set; }

        public string Classification { get; set; }

        public ICollection<Road_Craft> Road_Crafts { get; set; }

        public int Id { get; set; }
        public bool IsVisable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
