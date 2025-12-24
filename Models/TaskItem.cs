// // Models/TaskItem.cs
// namespace EmployeeTaskApi.Models
// {
//     public class TaskItem
//     {
//         public int TaskId { get; set; }
//         public int EmployeeId { get; set; }
//         public string Title { get; set; } = string.Empty;
//         public string Description { get; set; } = string.Empty;
//         public DateTime DueDate { get; set; }
//         public string Status { get; set; } = string.Empty;
//     }
// }



using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskApi.Models
{
    public class TaskItem
    {
        [Key] // ✅ TAMBAHAN WAJIB
        public int TaskId { get; set; }

        public int EmployeeId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
