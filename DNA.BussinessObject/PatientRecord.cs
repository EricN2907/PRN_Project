using System;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class PatientRecord
    {
        [Key]
        public int RecordId { get; set; }
        
        public int PatientId { get; set; }
        
        public int DoctorId { get; set; }
        
        public int? RegistrationId { get; set; }
        
        public DateTime RecordDate { get; set; } = DateTime.Now;
        
        public string RecordType { get; set; } = string.Empty; // Consultation, Test Result, Progress Note, etc.
        
        public string Title { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string TestResults { get; set; } = string.Empty;
        
        public string Diagnosis { get; set; } = string.Empty;
        
        public string Treatment { get; set; } = string.Empty;
        
        public string Recommendations { get; set; } = string.Empty;
        
        public string AttachmentUrls { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual TreatmentRegistration? TreatmentRegistration { get; set; }
    }
}
