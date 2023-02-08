using System.ComponentModel.DataAnnotations;

namespace NewRampUpAssign2.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [Required]
        public string? JobTitle { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        [StringLength(10)]
        public string? Mobile_no { get; set; }
        [Required]
        public string? Email { get; set; }

    }
}
