using Microsoft.AspNetCore.Mvc;
using EmployeeTaskApi.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ReportsController(AppDbContext context) => _context = context;

    [HttpGet("tasks")]
    public IActionResult GetReport()
    {
        var result = _context.Tasks
            .FromSqlRaw("EXEC sp_GetTaskReport")
            .ToList();
        return Ok(result);
    }
}
