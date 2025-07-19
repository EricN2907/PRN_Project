using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables; // This using directive is correct and necessary

namespace DNA.Repository
{
    public static class DatabaseConnection
    {
        private static IConfiguration? _configuration;

        static DatabaseConnection()
        {
            LoadConfiguration();
        }

        private static void LoadConfiguration()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(GetApplicationPath())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables(); // <-- Re-added this line, as the package is now installed

                _configuration = builder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
            }
        }

        private static string GetApplicationPath()
        {
            // Try to find the WPF app directory with appsettings.json
            string currentDir = Directory.GetCurrentDirectory();

            // Look for appsettings.json in current directory
            if (File.Exists(Path.Combine(currentDir, "appsettings.json")))
            {
                return currentDir;
            }

            // Look in parent directories
            DirectoryInfo? dir = Directory.GetParent(currentDir);
            while (dir != null)
            {
                string wpfAppPath = Path.Combine(dir.FullName, "DNA.WpfApp");
                if (Directory.Exists(wpfAppPath) && File.Exists(Path.Combine(wpfAppPath, "appsettings.json")))
                {
                    return wpfAppPath;
                }
                dir = dir.Parent;
            }

            // Fallback to current directory
            return currentDir;
        }

        public static string GetConnectionString(string? name = null)
        {
            string connectionStringName = name ?? "DefaultConnection";

            // Try to get from configuration
            string? connectionString = _configuration?.GetConnectionString(connectionStringName);

            // Fallback to default connection string if not found
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Server=NEM\\SQLEXPRESS;Database=FertilityTreatmentDB;User Id=sa;Password=12345;TrustServerCertificate=True;";
                Console.WriteLine($"Using default connection string for '{connectionStringName}'");
            }
            else
            {
                Console.WriteLine($"Using configured connection string for '{connectionStringName}'");
            }

            return connectionString;
        }

        public static DbContextOptions<ApplicationDbContext> GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            return optionsBuilder.Options;
        }

        // Alternative connection strings for different environments
        public static class ConnectionStrings
        {
            public static string Development => "Server=NEM\\SQLEXPRESS;Database=FertilityTreatmentDB;User Id=sa;Password=12345;TrustServerCertificate=True;";

            public static string DevelopmentIntegrated => "Server=NEM\\SQLEXPRESS;Database=FertilityTreatmentDB;Integrated Security=true;TrustServerCertificate=True;";

            public static string Production => "Server=PROD_SERVER;Database=FertilityTreatmentDB;User Id=prod_user;Password=prod_password;TrustServerCertificate=True;Encrypt=True;";

            public static string Testing => "Server=NEM\\SQLEXPRESS;Database=FertilityTreatmentDB_Test;User Id=sa;Password=12345;TrustServerCertificate=True;";
        }

        // Test connection method
        public static bool TestConnection(string? connectionString = null)
        {
            try
            {
                string connStr = connectionString ?? GetConnectionString();

                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(connStr)
                    .Options;

                using var context = new ApplicationDbContext(options);

                // Try to open connection and execute a simple query
                return context.Database.CanConnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection test failed: {ex.Message}");
                return false;
            }
        }
    }
}