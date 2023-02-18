using System.ComponentModel.DataAnnotations;

namespace MVCnWEBAPI.Models
{
    public class EmpInfo
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
