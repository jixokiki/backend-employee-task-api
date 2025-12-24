// using Microsoft.EntityFrameworkCore;
// using EmployeeTaskApi.Models;

// namespace EmployeeTaskApi.Data
// {
//     public class AppDbContext : DbContext
//     {
//         public AppDbContext(DbContextOptions options) : base(options) { }

//         public DbSet<User> Users { get; set; }
//         public DbSet<Employee> Employees { get; set; }
//         public DbSet<TaskItem> Tasks { get; set; }
//     }
// }


//Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using EmployeeTaskApi.Models;
using EmployeeTaskApi.Models;

namespace EmployeeTaskApi.Data
{
    public class AppDbContext : DbContext
    {
        // public AppDbContext(DbContextOptions options) : base(options) { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
