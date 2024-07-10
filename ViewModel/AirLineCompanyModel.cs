using AirLine.Models;
using System.ComponentModel.DataAnnotations;

namespace AirLine.ViewModel
{
    public class AirLineCompanyModel
    {


        [MaxLength(20)]
        public string Name { get; set; }
        public string Contact_Name { get; set; }
        public string? Address { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<AirCraft> AirCrafts { get; set; }

        public int Id { get; set; }
        public bool IsVisable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
