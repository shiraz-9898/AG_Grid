using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AG_Grid.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
      
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string? Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string? Designation { get; set; }
        [Column(TypeName = "numeric(10,2)")]

        public decimal Salary { get; set; }
    }
}
