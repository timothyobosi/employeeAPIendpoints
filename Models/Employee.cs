using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace empAI.Models
{
    public class Employee
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "longtext")]
        public string EmployeeFirstName { get; set; }

        [Required]
        [Column(TypeName = "longtext")]
        public string EmployeeLastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EmployeeDateOfBirth { get; set; }


    }
}
