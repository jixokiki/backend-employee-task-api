// using Microsoft.AspNetCore.Mvc;
// using EmployeeTaskApi.Data;
// using EmployeeTaskApi.Models;

// [ApiController]
// [Route("api/tasks")]
// public class TasksController : ControllerBase
// {
//     private readonly AppDbContext _context;
//     public TasksController(AppDbContext context) => _context = context;

//     [HttpPost]
//     public IActionResult Post(TaskItem task)
//     {
//         _context.Tasks.Add(task);
//         _context.SaveChanges();
//         return Ok(task);
//     }

//     [HttpPut("{id}")]
//     public IActionResult Update(int id, TaskItem task)
//     {
//         var existing = _context.Tasks.Find(id);
//         if (existing == null) return NotFound();

//         existing.Title = task.Title;
//         existing.Description = task.Description;
//         existing.DueDate = task.DueDate;
//         existing.Status = task.Status;

//         _context.SaveChanges();
//         return Ok(existing);
//     }

//     [HttpDelete("{id}")]
//     public IActionResult Delete(int id)
//     {
//         var existing = _context.Tasks.Find(id);
//         if (existing == null) return NotFound();

//         _context.Tasks.Remove(existing);
//         _context.SaveChanges();
//         return NoContent();
//     }

// }




using Microsoft.AspNetCore.Mvc;
using EmployeeTaskApi.Data;
using EmployeeTaskApi.Models;
using EmployeeTaskApi.Hubs;
using Microsoft.AspNetCore.SignalR;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IHubContext<TaskHub> _hub;

    public TasksController(AppDbContext context, IHubContext<TaskHub> hub)
    {
        _context = context;
        _hub = hub;
    }

    [HttpPost]
    public async Task<IActionResult> Post(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        // ✅ Trigger notifikasi ke frontend
        // await _hub.Clients.All.SendAsync("ReceiveTask", $"Task baru: {task.Title}");
        await _hub.Clients.All.SendAsync("ReceiveTask", task);


        return Ok(task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TaskItem task)
    {
        var existing = _context.Tasks.Find(id);
        if (existing == null) return NotFound();

        existing.Title = task.Title;
        existing.Description = task.Description;
        existing.DueDate = task.DueDate;
        existing.Status = task.Status;

        await _context.SaveChangesAsync();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = _context.Tasks.Find(id);
        if (existing == null) return NotFound();

        _context.Tasks.Remove(existing);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Tasks
            .OrderByDescending(t => t.TaskId)
            .ToList());
    }

}
