using AirLine.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AirLine.ViewModel
{
    public class TransactionModel
    {

        [NotNull]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal Amount_Money { get; set; }

        public AirLine_Company AirLine { get; set; }
        public int AirlineId { get; set; }

        public List<AirLine_Company> AirLines { get; set; }
        public long Id { get; set; }
        public bool IsVisable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
