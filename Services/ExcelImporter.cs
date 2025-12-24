// using System;
// using System.IO;
// using OfficeOpenXml;
// // using Microsoft.Data.SqlClient;
// using System.Data.SqlClient;


// namespace EmployeeTaskApi.Services
// {
//     public class ExcelImporter
//     {
//         private readonly string _connectionString;

//         public ExcelImporter(string connectionString)
//         {
//             _connectionString = connectionString;
//         }

//         public void ImportEmployees(string filePath)
//         {
//             // ✅ Validasi connection string dulu
//             if (string.IsNullOrEmpty(_connectionString))
//                 throw new Exception("Connection string is null or empty");

//             Console.WriteLine($"[DEBUG] Full connection string: {_connectionString}");

//             ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
//             using var package = new ExcelPackage(new FileInfo(filePath));

//             if (package?.Workbook?.Worksheets == null || package.Workbook.Worksheets.Count == 0)
//                 throw new Exception("File Excel tidak memiliki worksheet.");

//             var worksheet = package.Workbook.Worksheets[0];
//             if (worksheet?.Dimension == null)
//                 throw new Exception("Worksheet Excel kosong.");

//             int rowCount = worksheet.Dimension.Rows;

//             Console.WriteLine($"[DEBUG] Creating SqlConnection...");
//             SqlConnection connection = null;

//             try
//             {
//                 connection = new SqlConnection(_connectionString);
//                 Console.WriteLine($"[DEBUG] SqlConnection created: {connection != null}");

//                 connection.Open();
//                 Console.WriteLine($"[DEBUG] Connection opened, state: {connection.State}");

//                 for (int row = 2; row <= rowCount; row++)
//                 {
//                     var name = worksheet.Cells[row, 1]?.Text?.Trim();
//                     var email = worksheet.Cells[row, 2]?.Text?.Trim();
//                     var position = worksheet.Cells[row, 3]?.Text?.Trim();
//                     var isActiveCell = worksheet.Cells[row, 4];
//                     var isActiveText = isActiveCell?.Text;

//                     bool isActive = false;
//                     if (!string.IsNullOrEmpty(isActiveText))
//                     {
//                         isActiveText = isActiveText.Trim().ToLower();
//                         isActive = (isActiveText == "true" || isActiveText == "1");
//                     }

//                     if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(email))
//                         continue;

//                     Console.WriteLine($"[DEBUG] Creating command for row {row}...");
//                     var cmd = connection.CreateCommand();
//                     Console.WriteLine($"[DEBUG] Command created: {cmd != null}");

//                     cmd.CommandText = "INSERT INTO Employees (Name, Email, Position, IsActive) VALUES (@Name, @Email, @Position, @IsActive)";
//                     cmd.Parameters.AddWithValue("@Name", name ?? (object)DBNull.Value);
//                     cmd.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
//                     cmd.Parameters.AddWithValue("@Position", position ?? (object)DBNull.Value);
//                     cmd.Parameters.AddWithValue("@IsActive", isActive);
//                     cmd.ExecuteNonQuery();
//                     cmd.Dispose();

//                     Console.WriteLine($"[DEBUG] Row {row} inserted");
//                 }
//             }
//             finally
//             {
//                 connection?.Dispose();
//             }
//         }
//     }
// }




using System;
using System.IO;
using OfficeOpenXml;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeeTaskApi.Services
{
    public class ExcelImporter
    {
        private readonly string _connectionString;

        // 🔹 CONSTRUCTOR LAMA (TIDAK DIUBAH)
        // public ExcelImporter(string connectionString)
        // {
        //     _connectionString = connectionString;
        // }

        // 🔹 CONSTRUCTOR BARU (AMBIL DARI appsettings.json)
        public ExcelImporter(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("AdoConnection");
        }

        public void ImportEmployees(string filePath)
        {
            // ✅ Validasi connection string dulu
            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("Connection string is null or empty");

            Console.WriteLine($"[DEBUG] Full connection string: {_connectionString}");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(new FileInfo(filePath));

            if (package?.Workbook?.Worksheets == null || package.Workbook.Worksheets.Count == 0)
                throw new Exception("File Excel tidak memiliki worksheet.");

            var worksheet = package.Workbook.Worksheets[0];
            if (worksheet?.Dimension == null)
                throw new Exception("Worksheet Excel kosong.");

            int rowCount = worksheet.Dimension.Rows;

            Console.WriteLine($"[DEBUG] Creating SqlConnection...");
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(_connectionString);
                Console.WriteLine($"[DEBUG] SqlConnection created: {connection != null}");

                connection.Open();
                Console.WriteLine($"[DEBUG] Connection opened, state: {connection.State}");

                for (int row = 2; row <= rowCount; row++)
                {
                    var name = worksheet.Cells[row, 1]?.Text?.Trim();
                    var email = worksheet.Cells[row, 2]?.Text?.Trim();
                    var position = worksheet.Cells[row, 3]?.Text?.Trim();
                    var isActiveCell = worksheet.Cells[row, 4];
                    var isActiveText = isActiveCell?.Text;

                    bool isActive = false;
                    if (!string.IsNullOrEmpty(isActiveText))
                    {
                        isActiveText = isActiveText.Trim().ToLower();
                        isActive = (isActiveText == "true" || isActiveText == "1");
                    }

                    if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(email))
                        continue;

                    Console.WriteLine($"[DEBUG] Creating command for row {row}...");
                    using var cmd = connection.CreateCommand();

                    cmd.CommandText =
                        "INSERT INTO Employees (Name, Email, Position, IsActive) " +
                        "VALUES (@Name, @Email, @Position, @IsActive)";

                    cmd.Parameters.AddWithValue("@Name", name ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Position", position ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine($"[DEBUG] Row {row} inserted");
                }
            }
            finally
            {
                connection?.Dispose();
            }
        }
    }
}
