// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();






// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using EmployeeTaskApi.Data;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// // **Tambahkan DbContext untuk SQL Server**
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// // **Ambil JWT key dari appsettings.json**
// var jwtKey = builder.Configuration["Jwt:Key"] ?? "SUPER_SECRET_KEY_123";

// // **Tambahkan JWT Authentication**
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuer = false,
//             ValidateAudience = false,
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
//         };
//     });

// builder.Services.AddAuthorization();

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// // **Tambahkan Authentication & Authorization middleware**
// app.UseAuthentication();
// app.UseAuthorization();

// app.MapControllers();

// app.Run();





// //Empty Program.cs after refactor
// //ini yang sudah bener yaa ki cuman kurang di excelnya
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using EmployeeTaskApi.Data;

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = false,
//         ValidateAudience = false,
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123"))
//     };
// });

// builder.Services.AddAuthorization();
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseAuthentication();
// app.UseAuthorization();

// app.MapGet("/", () => Results.Content("<h1>Welcome to Employee Task & Schedule Management System</h1><p>API is running...</p>", "text/html"));


// app.MapControllers();
// app.Run();


//ini udah final Program.cs
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using EmployeeTaskApi.Data;
// using BCrypt.Net;
// using EmployeeTaskApi.Hubs;


// // AppContext.SetSwitch(
// //     "Switch.Microsoft.Data.SqlClient.UseManagedNetworkingOnMacOS",
// //     true
// // );

// // Tidak perlu set License di sini

// var builder = WebApplication.CreateBuilder(args);

// // builder.Services.AddDbContext<AppDbContext>(options =>
// //     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// // .AddJwtBearer(options =>
// // {
// //     options.TokenValidationParameters = new TokenValidationParameters
// //     {
// //         ValidateIssuer = false,
// //         ValidateAudience = false,
// //         ValidateIssuerSigningKey = true,
// //         IssuerSigningKey = new SymmetricSecurityKey(
// //             Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123"))
// //     };
// // });
// builder.Services.AddScoped<EmployeeTaskApi.Services.ExcelImporter>();

// // builder.Services.AddDbContext<AppDbContext>(options =>
// //     options.UseSqlServer(
// //         builder.Configuration.GetConnectionString("DefaultConnection"),
// //         sqlOptions =>
// //         {
// //             sqlOptions.EnableRetryOnFailure();
// //         }
// //     ));

// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(
//         builder.Configuration.GetConnectionString("EfConnection"),
//         sqlOptions =>
//         {
//             sqlOptions.EnableRetryOnFailure();
//         }
//     ));


// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = false,
//         ValidateAudience = false,
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123"))
//     };
// });


// builder.Services.AddAuthorization();
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // Add services
// builder.Services.AddSignalR();

// // TEMPORARY: generate hash password untuk update DB
// // Console.WriteLine("Hash password 'rizki': " + BCrypt.Net.BCrypt.HashPassword("rizki"));

// var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseRouting();

// // Map SignalR hub
// app.MapHub<TaskHub>("/taskHub");

// app.UseAuthentication();
// app.UseAuthorization();

// app.MapGet("/", () => Results.Content(
//     "<h1>Welcome to Employee Task & Schedule Management System</h1><p>API is running...</p>",
//     "text/html"));

// app.MapControllers();
// app.Run();



//update Program.cs dengan CORS dan static file yang sudah bener tahap dev
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using EmployeeTaskApi.Data;
// using EmployeeTaskApi.Hubs;
// using Microsoft.AspNetCore.Builder;

// var builder = WebApplication.CreateBuilder(args);

// // Database
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(
//         builder.Configuration.GetConnectionString("EfConnection"),
//         sqlOptions => sqlOptions.EnableRetryOnFailure()
//     ));

// // JWT Authentication
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = false,
//         ValidateAudience = false,
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123"))
//     };
// });

// // Authorization
// builder.Services.AddAuthorization();

// // Controllers & Swagger
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // SignalR
// builder.Services.AddSignalR();

// // ✅ CORS untuk frontend (sekarang sama origin dengan backend)
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(policy =>
//     {
//         policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500") // ✅ spesifik origin
//               .AllowAnyHeader()
//               .AllowAnyMethod()
//               .AllowCredentials(); // ✅ boleh karena origin spesifik
//     });
// });


// // Excel Importer (optional)
// builder.Services.AddScoped<EmployeeTaskApi.Services.ExcelImporter>();

// var app = builder.Build();

// // Swagger
// app.UseSwagger();
// app.UseSwaggerUI();

// // Static file: frontend bisa diakses dari backend
// app.UseDefaultFiles();   // index.html atau taskEmployee.html
// app.UseStaticFiles();

// app.UseRouting();

// // Enable CORS sebelum Auth & SignalR
// app.UseCors();

// app.UseAuthentication();
// app.UseAuthorization();

// // Map SignalR hub
// app.MapHub<TaskHub>("/taskHub");

// // Map controllers
// app.MapControllers();

// // Root endpoint
// app.MapGet("/", () => Results.Content(
//     "<h1>Welcome to Employee Task & Schedule Management System</h1><p>API is running...</p>",
//     "text/html"));

// app.Run();



// //Final Program.cs
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using EmployeeTaskApi.Data;
// using EmployeeTaskApi.Hubs;
// using Microsoft.AspNetCore.Builder;

// var builder = WebApplication.CreateBuilder(args);

// // ================= DATABASE =================
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(
//         builder.Configuration.GetConnectionString("EfConnection"),
//         sqlOptions => sqlOptions.EnableRetryOnFailure()
//     ));

// // ================= JWT AUTHENTICATION =================
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = false,
//         ValidateAudience = false,
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123"))
//     };

//     // 🔥 TAMBAHAN (WAJIB UNTUK SIGNALR - TANPA MERUBAH LOGIKA EXISTING)
//     options.Events = new JwtBearerEvents
//     {
//         OnMessageReceived = context =>
//         {
//             var accessToken = context.Request.Query["access_token"];
//             var path = context.HttpContext.Request.Path;

//             if (!string.IsNullOrEmpty(accessToken) &&
//                 path.StartsWithSegments("/taskHub"))
//             {
//                 context.Token = accessToken;
//             }

//             return Task.CompletedTask;
//         }
//     };
// });

// // ================= AUTHORIZATION =================
// builder.Services.AddAuthorization();

// // ================= CONTROLLERS & SWAGGER =================
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // ================= SIGNALR =================
// builder.Services.AddSignalR();

// // ================= CORS (DEFAULT POLICY, DIPERLUAS TANPA UBAH ALUR) =================
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(policy =>
//     {
//         policy.WithOrigins(
//                 // Existing
//                 "http://127.0.0.1:5500",
//                 "http://localhost:5500",
//                 "http://localhost:8081", // 👈 EXPO WEB
//                 "http://127.0.0.1:8081",

//                 // Tambahan (React / Expo / Network)
//                 "http://localhost:3000",
//                 "http://192.168.0.104:3000",
//                 "http://192.168.0.104:8081",

//                 // Production (siap pakai)
//                 "https://notifkemas.web.app",
//                 "https://notifkemas.firebaseapp.com"
//             )
//             .AllowAnyHeader()
//             .AllowAnyMethod()
//             .AllowCredentials();
//     });
// });

// // ================= SERVICES =================
// builder.Services.AddScoped<EmployeeTaskApi.Services.ExcelImporter>();

// var app = builder.Build();

// // ================= MIDDLEWARE PIPELINE =================
// app.UseSwagger();
// app.UseSwaggerUI();

// // Static file: frontend bisa diakses dari backend
// app.UseDefaultFiles();
// app.UseStaticFiles();

// app.UseRouting();

// // Enable CORS sebelum Auth & SignalR (TIDAK DIUBAH)
// app.UseCors();

// app.UseAuthentication();
// app.UseAuthorization();

// // ================= SIGNALR HUB =================
// app.MapHub<TaskHub>("/taskHub");

// // ================= API CONTROLLERS =================
// app.MapControllers();

// // ================= ROOT =================
// app.MapGet("/", () => Results.Content(
//     "<h1>Welcome to Employee Task & Schedule Management System</h1><p>API is running...</p>",
//     "text/html"));

// app.Run();







// // Final Program.cs
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using EmployeeTaskApi.Data;
// using EmployeeTaskApi.Hubs;
// using Microsoft.AspNetCore.Builder;

// var builder = WebApplication.CreateBuilder(args);

// // ================= DATABASE =================
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(
//         builder.Configuration.GetConnectionString("EfConnection"),
//         sqlOptions => sqlOptions.EnableRetryOnFailure()
//     ));

// // ================= JWT AUTHENTICATION =================
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = false,
//         ValidateAudience = false,
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(
//             Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123"))
//     };

//     // 🔥 SIGNALR JWT SUPPORT (TIDAK MENGUBAH LOGIKA EXISTING)
//     options.Events = new JwtBearerEvents
//     {
//         OnMessageReceived = context =>
//         {
//             var accessToken = context.Request.Query["access_token"];
//             var path = context.HttpContext.Request.Path;

//             if (!string.IsNullOrEmpty(accessToken) &&
//                 path.StartsWithSegments("/taskHub"))
//             {
//                 context.Token = accessToken;
//             }

//             return Task.CompletedTask;
//         }
//     };
// });

// // ================= AUTHORIZATION =================
// builder.Services.AddAuthorization();

// // ================= CONTROLLERS & SWAGGER =================
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // ================= SIGNALR =================
// builder.Services.AddSignalR();

// // ================= CORS (DEFAULT POLICY – DIPERLUAS TANPA UBAH ALUR) =================
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(policy =>
//     {
//         policy.WithOrigins(
//                 // Local Static / Dev
//                 "http://127.0.0.1:5500",
//                 "http://localhost:5500",
//                 "http://localhost:8081",      // Expo Web
//                 "http://127.0.0.1:8081",

//                 // Network / LAN
//                 "http://localhost:3000",
//                 "http://192.168.0.104:3000",
//                 "http://192.168.0.104:8081",

//                 // Production Firebase Hosting
//                 "https://notifkemas.web.app",
//                 "https://notifkemas.firebaseapp.com"
//             )
//             .AllowAnyHeader()
//             .AllowAnyMethod()
//             .AllowCredentials();
//     });
// });

// // ================= SERVICES =================
// builder.Services.AddScoped<EmployeeTaskApi.Services.ExcelImporter>();

// var app = builder.Build();

// // ================= MIDDLEWARE PIPELINE =================
// app.UseSwagger();
// app.UseSwaggerUI();

// // Static file support (TIDAK DIUBAH)
// app.UseDefaultFiles();
// app.UseStaticFiles();

// app.UseRouting();

// // ⚠️ CORS HARUS SEBELUM AUTH & SIGNALR
// app.UseCors();

// app.UseAuthentication();
// app.UseAuthorization();

// // ================= SIGNALR HUB =================
// app.MapHub<TaskHub>("/taskHub");

// // ================= API CONTROLLERS =================
// app.MapControllers();

// // ================= ROOT =================
// app.MapGet("/", () => Results.Content(
//     "<h1>Welcome to Employee Task & Schedule Management System</h1><p>API is running...</p>",
//     "text/html"));

// // ================= RUN (PORT DARI ENV – RAILWAY READY) =================
// app.Run();




// Final Program.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EmployeeTaskApi.Data;
using EmployeeTaskApi.Hubs;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// ================= DATABASE =================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EfConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));

// ================= JWT AUTHENTICATION =================
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("SUPER_SECRET_KEY_123"))
    };

    // 🔥 SIGNALR JWT SUPPORT (DARI CODE AWAL – TANPA UBAH LOGIKA)
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;

            if (!string.IsNullOrEmpty(accessToken) &&
                path.StartsWithSegments("/taskHub"))
            {
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
});

// ================= AUTHORIZATION =================
builder.Services.AddAuthorization();

// ================= CONTROLLERS & SWAGGER =================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ================= SIGNALR =================
builder.Services.AddSignalR();

// ================= CORS (DEFAULT POLICY – DIGABUNG TANPA UBAH ALUR) =================
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(
                // Local Static / Dev
                "http://127.0.0.1:5500",
                "http://localhost:5500",
                "http://localhost:8081",
                "http://127.0.0.1:8081",

                // Network / LAN
                "http://localhost:3000",
                "http://192.168.0.104:3000",
                "http://192.168.0.104:8081",

                // Production Firebase Hosting
                "https://notifkemas.web.app",
                "https://notifkemas.firebaseapp.com"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// ================= SERVICES =================
builder.Services.AddScoped<EmployeeTaskApi.Services.ExcelImporter>();

var app = builder.Build();

// ================= MIDDLEWARE PIPELINE =================
app.UseSwagger();
app.UseSwaggerUI();

// Static file support (TIDAK DIUBAH)
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

// ⚠️ CORS HARUS SEBELUM AUTH & SIGNALR (SESUAI CODE KAMU)
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

// ================= SIGNALR HUB =================
app.MapHub<TaskHub>("/taskHub");

// ================= API CONTROLLERS =================
app.MapControllers();

// ================= ROOT =================
app.MapGet("/", () => Results.Content(
    "<h1>Welcome to Employee Task & Schedule Management System</h1><p>API is running...</p>",
    "text/html"
));

// ================= RUN (RAILWAY READY) =================
app.Run();
