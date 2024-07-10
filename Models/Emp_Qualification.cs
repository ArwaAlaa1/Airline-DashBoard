using System.ComponentModel.DataAnnotations.Schema;

namespace AirLine.Models
{
	public class Emp_Qualification
	{

			[ForeignKey("EmployeeId")]
			public Employee Employee { get; set; }

			public int EmployeeId { get; set; }

			public string Qualification { get; set; }

		

		
	}
}
