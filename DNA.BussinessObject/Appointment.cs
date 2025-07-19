using System;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        
        public int PatientId { get; set; }
        
        public int? DoctorId { get; set; }
        
        public int? RegistrationId { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        
        public TimeSpan StartTime { get; set; }
        
        public TimeSpan EndTime { get; set; }
        
        [StringLength(50)]
        public string AppointmentType { get; set; } = string.Empty; // Consultation, CheckUp, Treatment, Test
        
        [StringLength(20)]
        public string Status { get; set; } = "Scheduled"; // Scheduled, Completed, Cancelled, NoShow
        
        public string Purpose { get; set; } = string.Empty;
        
        public string Notes { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? Location { get; set; }
        
        public int Duration { get; set; } = 30; // Duration in minutes
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        public bool ReminderSent { get; set; } = false;
        
        // Navigation properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual TreatmentRegistration? TreatmentRegistration { get; set; }
    }
}
