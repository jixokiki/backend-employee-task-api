// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Text;
// using EmployeeTaskApi.DTOs;

// [ApiController]
// [Route("api/auth")]
// public class AuthController : ControllerBase
// {
//     [HttpPost("login")]
//     public IActionResult Login(LoginDto dto)
//     {
//         if (dto.Username == "admin" && dto.Password == "admin")
//         {
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var key = Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123");

//             var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
//             {
//                 Expires = DateTime.UtcNow.AddHours(1),
//                 SigningCredentials = new SigningCredentials(
//                     new SymmetricSecurityKey(key),
//                     SecurityAlgorithms.HmacSha256Signature)
//             });

//             return Ok(new { token = tokenHandler.WriteToken(token) });
//         }
//         return Unauthorized();
//     }
// }



using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using EmployeeTaskApi.DTOs;
using EmployeeTaskApi.Data;  // Tambahkan ini
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    public AuthController(AppDbContext context) => _context = context;

    // [HttpPost("login")]
    // public IActionResult Login(LoginDto dto)
    // {
    //     // var user = _context.Users.SingleOrDefault(u => u.Username == dto.Username);
    //     var user = _context.Users.AsNoTracking().SingleOrDefault(u => u.Username == dto.Username);

    //     if (user == null) return Unauthorized();

    //     // Verifikasi password (plain text contoh, bisa pakai hash)
    //     if (user.PasswordHash != dto.Password) return Unauthorized();

    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123");

    //     var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
    //     {
    //         Expires = DateTime.UtcNow.AddHours(1),
    //         SigningCredentials = new SigningCredentials(
    //             new SymmetricSecurityKey(key),
    //             SecurityAlgorithms.HmacSha256Signature)
    //     });

    //     return Ok(new { token = tokenHandler.WriteToken(token) });
    // }

    [HttpPost("login")]
public IActionResult Login(LoginDto dto)
{
    var user = _context.Users.AsNoTracking()
        .SingleOrDefault(u => u.Username == dto.Username);

    if (user == null)
        return Unauthorized("User tidak ditemukan");

    bool validPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
    if (!validPassword)
        return Unauthorized("Password salah");

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(
        "THIS_IS_SUPER_SECRET_KEY_MIN_32_CHARS_2025"
    );

    var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
    {
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        )
    });

    return Ok(new { token = tokenHandler.WriteToken(token) });
}

}
