using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using DNA.Repository;
using Microsoft.EntityFrameworkCore;

namespace DNA.WpfApp.Helpers
{
    public static class DatabaseHelper
    {


        /// <summary>
        /// Lấy connection string từ App.config
        /// </summary>
        public static string GetConnectionStringFromConfig(string? name = null)
        {
            try
            {
                string connectionName = name ?? "DefaultConnection";
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName]?.ConnectionString;
                
                if (string.IsNullOrEmpty(connectionString))
                {
                    // Fallback to default
                    return "Server=NEM\\SQLEXPRESS;Database=FertilityTreatmentDB;User Id=sa;Password=12345;TrustServerCertificate=True;";
                }

                return connectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading connection string: {ex.Message}", "Configuration Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return "Server=NEM\\SQLEXPRESS;Database=FertilityTreatmentDB;User Id=sa;Password=12345;TrustServerCertificate=True;";
            }
        }

        /// <summary>
        /// Khởi tạo database nếu chưa tồn tại
        /// </summary>
        public static async Task<bool> EnsureDatabaseCreatedAsync()
        {
            try
            {
                using var context = new ApplicationDbContext();
                await context.Database.EnsureCreatedAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating database: {ex.Message}", "Database Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Chạy migrations nếu có
        /// </summary>
        public static async Task<bool> MigrateDatabaseAsync()
        {
            try
            {
                using var context = new ApplicationDbContext();
                await context.Database.MigrateAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error migrating database: {ex.Message}", "Migration Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Hiển thị thông tin connection hiện tại
        /// </summary>
        public static string GetCurrentConnectionInfo()
        {
            try
            {
                string connectionString = DatabaseConnection.GetConnectionString();
                
                // Extract server and database name for display
                var parts = connectionString.Split(';');
                string server = "Unknown";
                string database = "Unknown";

                foreach (var part in parts)
                {
                    if (part.ToLower().StartsWith("server="))
                        server = part.Substring(7);
                    else if (part.ToLower().StartsWith("database="))
                        database = part.Substring(9);
                }

                return $"Server: {server}\nDatabase: {database}";
            }
            catch (Exception ex)
            {
                return $"Error getting connection info: {ex.Message}";
            }
        }
    }
}
