using AirLine.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace AirLine.Models
{
    public class Transaction:Entity<long>
    {

        //tran_id /description/date/ amount /air_id

        [NotNull]
        public string Description { get; set; }

		
		[Column(TypeName ="date")]
        public DateTime Date { get; set; }

        [Column(TypeName ="money")]
        [DataType(DataType.Currency)] 
        public decimal  Amount_Money { get; set; }

        public AirLine_Company AirLine { get; set; }
        public int AirlineId { get; set; }

    }
}
