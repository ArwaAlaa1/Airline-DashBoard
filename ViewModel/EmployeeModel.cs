using AirLine.Models;
using System.ComponentModel.DataAnnotations;

namespace AirLine.ViewModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsVisible { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

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

        public List<AirLine_Company> AirLines_list { get; set; }
    }
}
