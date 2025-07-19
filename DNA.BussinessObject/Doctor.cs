using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LicenseNumber { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Specialization { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string Qualification { get; set; } = string.Empty;
        
        public int? Experience { get; set; } // Years of experience
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Legacy properties for backward compatibility
        [Required]
        public string FullName { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Phone { get; set; } = string.Empty;
        
        public string Degree { get; set; } = string.Empty;
        
        public int YearsOfExperience { get; set; }
        
        public string Bio { get; set; } = string.Empty;
        
        public string Biography { get; set; } = string.Empty;
        
        public string ImageUrl { get; set; } = string.Empty;
        
        public decimal ConsultationFee { get; set; }
        
        public bool IsAvailable { get; set; } = true;
        
        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
        public virtual ICollection<TreatmentRegistration> TreatmentRegistrations { get; set; } = new List<TreatmentRegistration>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<PatientRecord> PatientRecords { get; set; } = new List<PatientRecord>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
