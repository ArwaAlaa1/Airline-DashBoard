using AirLine.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLine.ViewModel
{
	public class QualificationsModel
	{

		[Key, Column(Order = 1)]
		[ForeignKey("EmployeeId")]
			public Employee Employee { get; set; }

			public int EmployeeId { get; set; }

		[Key, Column(Order = 2)]
		public string Qualification { get; set; }

			public List<Employee> Employees { get; set; }
		
	}
}
