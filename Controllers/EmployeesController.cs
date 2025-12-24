// using Microsoft.AspNetCore.Mvc;
// using EmployeeTaskApi.Data;
// using EmployeeTaskApi.Models;


// [ApiController]
// [Route("api/employees")]
// public class EmployeesController : ControllerBase
// {
//     private readonly AppDbContext _context;
//     public EmployeesController(AppDbContext context) => _context = context;

//     [HttpGet]
//     public IActionResult Get() => Ok(_context.Employees.ToList());

//     [HttpPost]
//     public IActionResult Post(Employee emp)
//     {
//         _context.Employees.Add(emp);
//         _context.SaveChanges();
//         return Ok(emp);
//     }

//     [HttpPut("{id}")]
//     public IActionResult Update(int id, Employee emp)
//     {
//         var existing = _context.Employees.Find(id);
//         if (existing == null) return NotFound();

//         existing.Name = emp.Name;
//         existing.Email = emp.Email;
//         existing.Position = emp.Position;
//         existing.IsActive = emp.IsActive;

//         _context.SaveChanges();
//         return Ok(existing);
//     }

//     [HttpDelete("{id}")]
//     public IActionResult Delete(int id)
//     {
//         var existing = _context.Employees.Find(id);
//         if (existing == null) return NotFound();

//         _context.Employees.Remove(existing);
//         _context.SaveChanges();
//         return NoContent();
//     }

// }


//Controlles/EmployeesController.cs
//ini udah bener yaa ki cuman kurang di excelnya aja
using Microsoft.AspNetCore.Mvc;
using EmployeeTaskApi.Data;
using EmployeeTaskApi.Models;
using Microsoft.AspNetCore.Http;
using EmployeeTaskApi.Services;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config; // untuk connection string

    // public EmployeesController(AppDbContext context, IConfiguration config)
    // {
    //     _context = context;
    //     _config = config;
    // }
    private readonly ExcelImporter _excelImporter;

    public EmployeesController(AppDbContext context, ExcelImporter excelImporter)
    {
        _context = context;
        _excelImporter = excelImporter;
    }


    [HttpGet]
    public IActionResult Get() => Ok(_context.Employees.ToList());

    [HttpPost]
    public IActionResult Post(Employee emp)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Employees.Add(emp);
        _context.SaveChanges();
        return Ok(emp);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee emp)
    {
        var existing = _context.Employees.Find(id);
        if (existing == null) return NotFound();

        existing.Name = emp.Name;
        existing.Email = emp.Email;
        existing.Position = emp.Position;
        existing.IsActive = emp.IsActive;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existing = _context.Employees.Find(id);
        if (existing == null) return NotFound();

        _context.Employees.Remove(existing);
        _context.SaveChanges();
        return NoContent();
    }

    // [HttpPost("import-excel")]
    // public IActionResult ImportExcel(IFormFile file)
    // {
    //     if (file == null || file.Length == 0)
    //         return BadRequest("File tidak ditemukan.");

    //     // Simpan sementara file
    //     var tempFile = Path.GetTempFileName();
    //     using (var stream = System.IO.File.Create(tempFile))
    //     {
    //         file.CopyTo(stream);
    //     }

    //     // Ambil connection string
    //     var connString = _config.GetConnectionString("DefaultConnection");
    //     if (string.IsNullOrEmpty(connString))
    //     {
    //         if (System.IO.File.Exists(tempFile)) System.IO.File.Delete(tempFile);
    //         return BadRequest("Connection string tidak ditemukan.");
    //     }

    //     var importer = new ExcelImporter(connString);

    //     try
    //     {
    //         importer.ImportEmployees(tempFile);
    //         return Ok("Data berhasil diimport.");
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest($"Gagal import data: {ex.Message}");
    //     }
    //     finally
    //     {
    //         if (System.IO.File.Exists(tempFile))
    //             System.IO.File.Delete(tempFile);
    //     }
    // }

    // [HttpPost("import-excel")]
    // public IActionResult ImportExcel(IFormFile file)
    // {
    //     if (file == null || file.Length == 0)
    //         return BadRequest("File tidak ditemukan.");

    //     // Simpan sementara file
    //     var tempFile = Path.GetTempFileName();
    //     using (var stream = System.IO.File.Create(tempFile))
    //     {
    //         file.CopyTo(stream);
    //     }

    //     // Ambil connection string
    //     var connString = _config.GetConnectionString("DefaultConnection");
    //     if (string.IsNullOrEmpty(connString))
    //     {
    //         if (System.IO.File.Exists(tempFile)) System.IO.File.Delete(tempFile);
    //         return BadRequest("Connection string tidak ditemukan.");
    //     }

    //     var importer = new ExcelImporter(connString);

    //     try
    //     {
    //         importer.ImportEmployees(tempFile);
    //         return Ok("Data berhasil diimport.");
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest($"Gagal import data: {ex.Message}");
    //     }
    //     finally
    //     {
    //         if (System.IO.File.Exists(tempFile))
    //             System.IO.File.Delete(tempFile);
    //     }
    // }

    // ✅ VERSI DENGAN LOGGING LEBIH DETAIL
    // [HttpPost("import-excel")]
    // public IActionResult ImportExcel(IFormFile file)
    // {
    //     if (file == null || file.Length == 0)
    //         return BadRequest("File tidak ditemukan.");

    //     // Simpan sementara file
    //     var tempFile = Path.GetTempFileName();

    //     // ✅ TAMBAHAN LOG
    //     Console.WriteLine($"[DEBUG] Temp file: {tempFile}");
    //     Console.WriteLine($"[DEBUG] File name: {file.FileName}");
    //     Console.WriteLine($"[DEBUG] File size: {file.Length}");

    //     using (var stream = System.IO.File.Create(tempFile))
    //     {
    //         file.CopyTo(stream);
    //     }

    //     // ✅ TAMBAHAN LOG
    //     Console.WriteLine($"[DEBUG] File copied, checking exists: {System.IO.File.Exists(tempFile)}");
    //     Console.WriteLine($"[DEBUG] File size after copy: {new FileInfo(tempFile).Length}");

    //     // Ambil connection string
    //     var connString = _config.GetConnectionString("DefaultConnection");

    //     // ✅ TAMBAHAN LOG
    //     Console.WriteLine($"[DEBUG] Connection string null? {string.IsNullOrEmpty(connString)}");
    //     Console.WriteLine($"[DEBUG] Connection string: {connString?.Substring(0, Math.Min(30, connString?.Length ?? 0))}...");

    //     if (string.IsNullOrEmpty(connString))
    //     {
    //         if (System.IO.File.Exists(tempFile)) System.IO.File.Delete(tempFile);
    //         return BadRequest("Connection string tidak ditemukan.");
    //     }

    //     var importer = new ExcelImporter(connString);

    //     try
    //     {
    //         // ✅ TAMBAHAN LOG
    //         Console.WriteLine($"[DEBUG] Starting import...");
    //         importer.ImportEmployees(tempFile);
    //         Console.WriteLine($"[DEBUG] Import success!");
    //         return Ok("Data berhasil diimport.");
    //     }
    //     catch (Exception ex)
    //     {
    //         // ✅ TAMBAHAN LOG DETAIL
    //         Console.WriteLine($"[ERROR] Exception Type: {ex.GetType().FullName}");
    //         Console.WriteLine($"[ERROR] Message: {ex.Message}");
    //         Console.WriteLine($"[ERROR] Stack Trace:");
    //         Console.WriteLine(ex.StackTrace);

    //         if (ex.InnerException != null)
    //         {
    //             Console.WriteLine($"[ERROR] Inner Exception: {ex.InnerException.Message}");
    //             Console.WriteLine($"[ERROR] Inner Stack Trace:");
    //             Console.WriteLine(ex.InnerException.StackTrace);
    //         }

    //         return BadRequest($"Gagal import data: {ex.Message}");
    //     }
    //     finally
    //     {
    //         if (System.IO.File.Exists(tempFile))
    //             System.IO.File.Delete(tempFile);
    //     }
    // }

    [HttpPost("import-excel")]
    public IActionResult ImportExcel(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File tidak ditemukan.");

        var tempFile = Path.GetTempFileName();

        Console.WriteLine($"[DEBUG] Temp file: {tempFile}");
        Console.WriteLine($"[DEBUG] File name: {file.FileName}");
        Console.WriteLine($"[DEBUG] File size: {file.Length}");

        using (var stream = System.IO.File.Create(tempFile))
        {
            file.CopyTo(stream);
        }

        Console.WriteLine($"[DEBUG] File copied, exists: {System.IO.File.Exists(tempFile)}");
        Console.WriteLine($"[DEBUG] File size after copy: {new FileInfo(tempFile).Length}");

        try
        {
            Console.WriteLine($"[DEBUG] Starting import...");
            _excelImporter.ImportEmployees(tempFile);
            Console.WriteLine($"[DEBUG] Import success!");
            return Ok("Data berhasil diimport.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Exception Type: {ex.GetType().FullName}");
            Console.WriteLine($"[ERROR] Message: {ex.Message}");
            Console.WriteLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine($"[ERROR] Inner: {ex.InnerException.Message}");
                Console.WriteLine(ex.InnerException.StackTrace);
            }

            return BadRequest($"Gagal import data: {ex.Message}");
        }
        finally
        {
            if (System.IO.File.Exists(tempFile))
                System.IO.File.Delete(tempFile);
        }
    }



}
