using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLine.Entity
{
    public class Entity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public T Id { get; set; }
        public bool IsVisable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
