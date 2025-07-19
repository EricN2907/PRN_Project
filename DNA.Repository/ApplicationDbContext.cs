using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DNA.BussinessObject;
using Microsoft.Extensions.Configuration;

namespace DNA.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration? _configuration;

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) 
            : base(options)
        {
            _configuration = configuration;
        }

        // User Management
        public DbSet<User> Users { get; set; }
        
        // Patient Management  
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }
        
        // Doctor Management
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        
        // DNA Testing Services
        public DbSet<TreatmentService> DNATestServices { get; set; }
        
        // DNA Test Management
        public DbSet<TreatmentRegistration> DNATestRegistrations { get; set; }
        public DbSet<TreatmentProgress> TestProgress { get; set; }
        
        // Sample Collection (using existing entities)
        // Note: We'll need to create new entities for complete DNA testing functionality
        
        // Appointment Management
        public DbSet<Appointment> Appointments { get; set; }
        
        // Rating & Feedback
        public DbSet<Rating> PatientFeedback { get; set; }
        
        // Content Management
        public DbSet<BlogPost> BlogPosts { get; set; }
        
        // Notification System
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = DatabaseConnection.GetConnectionString();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Primary Keys explicitly
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientId);
            modelBuilder.Entity<PatientRecord>().HasKey(pr => pr.RecordId);
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<DoctorSchedule>().HasKey(ds => ds.ScheduleId);
            modelBuilder.Entity<TreatmentService>().HasKey(ts => ts.ServiceId);
            modelBuilder.Entity<TreatmentRegistration>().HasKey(tr => tr.RegistrationId);
            modelBuilder.Entity<TreatmentProgress>().HasKey(tp => tp.ProgressId);
            modelBuilder.Entity<Appointment>().HasKey(a => a.AppointmentId);
            modelBuilder.Entity<Rating>().HasKey(r => r.RatingId);
            modelBuilder.Entity<BlogPost>().HasKey(bp => bp.PostId);
            modelBuilder.Entity<Notification>().HasKey(n => n.NotificationId);

            // Configure table names to match database schema
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<PatientRecord>().ToTable("PatientRecords");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<DoctorSchedule>().ToTable("DoctorSchedules");
            modelBuilder.Entity<TreatmentService>().ToTable("DNATestServices");
            modelBuilder.Entity<TreatmentRegistration>().ToTable("DNATestRegistrations");
            modelBuilder.Entity<TreatmentProgress>().ToTable("TestProgress");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Rating>().ToTable("PatientFeedback");
            modelBuilder.Entity<BlogPost>().ToTable("BlogPosts");
            modelBuilder.Entity<Notification>().ToTable("Notifications");

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();
                entity.Property(e => e.FullName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.UserType).HasMaxLength(20).IsRequired();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Username).IsUnique();
            });

            // Configure Patient entity
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Gender).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.EmergencyContact).HasMaxLength(100);
                entity.Property(e => e.EmergencyPhone).HasMaxLength(20);
                entity.Property(e => e.BloodType).HasMaxLength(5);
                entity.Property(e => e.Allergies).HasMaxLength(500);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                
                // Foreign key to Users table
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure DNA Test Service entity
            modelBuilder.Entity<TreatmentService>(entity =>
            {
                entity.Property(e => e.ServiceName).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Description).HasColumnType("nvarchar(max)");
                entity.Property(e => e.Price).HasPrecision(18, 2);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                
                // Add DNA-specific properties through shadow properties
                entity.Property<string>("ServiceCode").HasMaxLength(20);
                entity.Property<string>("ServiceType").HasMaxLength(50);
                entity.Property<int>("EstimatedDays").HasDefaultValue(7);
                entity.Property<bool>("RequiresSample").HasDefaultValue(true);
                entity.Property<bool>("AllowHomeSample").HasDefaultValue(true);
                entity.Property<bool>("AllowClinicSample").HasDefaultValue(true);
            });

            // Configure DNA Test Registration entity
            modelBuilder.Entity<TreatmentRegistration>(entity =>
            {
                entity.Property(e => e.Status).HasMaxLength(30).HasDefaultValue("Đã đăng ký");
                entity.Property(e => e.TotalCost).HasPrecision(18, 2);
                entity.Property(e => e.PaidAmount).HasPrecision(18, 2).HasDefaultValue(0);
                entity.Property(e => e.PaymentStatus).HasMaxLength(20).HasDefaultValue("Chưa thanh toán");
                entity.Property(e => e.Notes).HasColumnType("nvarchar(max)");
                
                // Add DNA-specific properties through shadow properties
                entity.Property<string>("SampleCollectionMethod").HasMaxLength(20);
                entity.Property<string>("Priority").HasMaxLength(20).HasDefaultValue("Bình thường");
                entity.Property<DateTime?>("ExpectedCompletionDate");
                entity.Property<DateTime?>("ActualCompletionDate");
                entity.Property<int>("CreatedBy");
                entity.Property<int?>("AssignedStaff");

                // Relationships
                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.TreatmentRegistrations)
                    .HasForeignKey(e => e.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne(e => e.TreatmentService)
                    .WithMany()
                    .HasForeignKey(e => e.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("CreatedBy")
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("AssignedStaff")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure Test Progress entity
            modelBuilder.Entity<TreatmentProgress>(entity =>
            {
                entity.Property(e => e.StepName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.StepDescription).HasMaxLength(500);
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Chờ xử lý");
                entity.Property(e => e.Notes).HasColumnType("nvarchar(max)");
                
                // Add DNA-specific properties
                entity.Property<int>("StepOrder");
                entity.Property<DateTime?>("StartDate");
                entity.Property<DateTime?>("CompletedDate");
                entity.Property<int?>("PerformedBy");

                // Relationships
                entity.HasOne(e => e.TreatmentRegistration)
                    .WithMany(tr => tr.TreatmentProgresses)
                    .HasForeignKey(e => e.RegistrationId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("PerformedBy")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure Doctor entity
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.LicenseNumber).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Specialization).HasMaxLength(200);
                entity.Property(e => e.Qualification).HasMaxLength(500);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                
                entity.HasIndex(e => e.LicenseNumber).IsUnique();
                
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Appointment entity
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentType).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Đã đặt");
                entity.Property(e => e.Location).HasMaxLength(200);
                entity.Property(e => e.Notes).HasColumnType("nvarchar(max)");
                entity.Property(e => e.Duration).HasDefaultValue(30);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                
                // Add DNA-specific properties
                entity.Property<int?>("RegistrationId");
                entity.Property<int?>("AssignedStaff");

                // Relationships
                entity.HasOne(e => e.Patient)
                    .WithMany()
                    .HasForeignKey(e => e.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne<TreatmentRegistration>()
                    .WithMany()
                    .HasForeignKey("RegistrationId")
                    .OnDelete(DeleteBehavior.SetNull);
                    
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("AssignedStaff")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure Patient Feedback (Rating) entity
            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.RatingValue).HasColumnName("Rating");
                entity.Property(e => e.Comment).HasColumnType("nvarchar(max)");
                entity.Property(e => e.RatedDate).HasDefaultValueSql("GETDATE()");
                
                // Add DNA-specific properties
                entity.Property<int?>("RegistrationId");
                entity.Property<string>("FeedbackType").HasMaxLength(30);
                entity.Property<string>("Title").HasMaxLength(200);
                entity.Property<bool>("IsPublic").HasDefaultValue(false);
                entity.Property<bool>("IsVerified").HasDefaultValue(false);
                entity.Property<string>("ResponseFromStaff").HasColumnType("nvarchar(max)");
                entity.Property<DateTime?>("ResponseDate");
                entity.Property<int?>("ResponseBy");

                // Relationships
                entity.HasOne(e => e.Patient)
                    .WithMany()
                    .HasForeignKey(e => e.PatientId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne<TreatmentRegistration>()
                    .WithMany()
                    .HasForeignKey("RegistrationId")
                    .OnDelete(DeleteBehavior.SetNull);
                    
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("ResponseBy")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure Blog Post entity
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(300).IsRequired();
                entity.Property(e => e.Slug).HasMaxLength(300).IsRequired();
                entity.Property(e => e.Content).HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(e => e.Summary).HasMaxLength(500);
                entity.Property(e => e.Category).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Tags).HasMaxLength(500);
                entity.Property(e => e.FeaturedImage).HasMaxLength(500);
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Draft");
                entity.Property(e => e.ViewCount).HasDefaultValue(0);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                
                entity.HasIndex(e => e.Slug).IsUnique();
                
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Notification entity
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationType).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Title).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Message).HasColumnType("nvarchar(max)").IsRequired();
                entity.Property(e => e.IsRead).HasDefaultValue(false);
                entity.Property(e => e.IsSent).HasDefaultValue(false);
                entity.Property(e => e.SendMethod).HasMaxLength(20);
                entity.Property(e => e.RelatedEntityType).HasMaxLength(50);
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
                
                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
