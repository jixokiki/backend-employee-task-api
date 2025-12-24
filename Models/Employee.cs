// // Models/Employee.cs
// namespace EmployeeTaskApi.Models
// {
//     public class Employee
//     {
//         public int EmployeeId { get; set; }
//         public string Name { get; set; }
//         public string Email { get; set; }
//         public string Position { get; set; }
//         public bool IsActive { get; set; }
//     }
// }



// Models/Employee.cs
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskApi.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Position is required")]
        [StringLength(50, ErrorMessage = "Position cannot exceed 50 characters")]
        public string Position { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
