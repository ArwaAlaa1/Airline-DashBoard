using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirLine.Models
{
	//[PrimaryKey(nameof(AirLineId), nameof(Phones))]
	public class Airline_Phones
    {
		[Key, Column(Order = 1)]
		[ForeignKey("AirLineId")]
		public AirLine_Company AirLine { get; set; }
		public int AirLineId { get; set; }

		[Key, Column(Order = 2)]
		[MaxLength(11)]
		public string Phones { get; set; }

		
	}
}
