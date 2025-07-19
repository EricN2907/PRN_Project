using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        
        public int? UserId { get; set; }
        
        [Required]
        public string FullName { get; set; } = string.Empty;
        
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public string Gender { get; set; } = string.Empty;
        
        [Required]
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public string MedicalHistory { get; set; } = string.Empty;
        
        public string EmergencyContact { get; set; } = string.Empty;
        
        public string EmergencyPhone { get; set; } = string.Empty;
        
        public string BloodType { get; set; } = string.Empty;
        
        public string Allergies { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        public bool IsActive { get; set; } = true;

        // Computed property
        public int Age => DateTime.Now.Year - DateOfBirth.Year - 
            (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
        
        // Navigation properties
        public virtual ICollection<TreatmentRegistration> TreatmentRegistrations { get; set; } = new List<TreatmentRegistration>();
        public virtual ICollection<PatientRecord> PatientRecords { get; set; } = new List<PatientRecord>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
