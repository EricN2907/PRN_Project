using System;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        
        public int? UserId { get; set; }
        
        public int? PatientId { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Message { get; set; } = string.Empty;
        
        public string NotificationType { get; set; } = string.Empty; // Appointment, Medication, Result, General
        
        public bool IsRead { get; set; } = false;
        
        public bool IsSent { get; set; } = false;
        
        [StringLength(20)]
        public string? SendMethod { get; set; } // Email, SMS, In-app, All
        
        public string Priority { get; set; } = "Normal"; // Low, Normal, High, Urgent
        
        [StringLength(50)]
        public string? RelatedEntityType { get; set; } // Registration, Appointment, Result, etc.
        
        public int? RelatedEntityId { get; set; }
        
        public DateTime? ScheduledDate { get; set; }
        
        public DateTime? SentDate { get; set; }
        
        public DateTime? ReadDate { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
