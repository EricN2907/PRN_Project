using System;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class TreatmentProgress
    {
        [Key]
        public int ProgressId { get; set; }
        
        public int RegistrationId { get; set; }
        
        public int? StepId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string StepName { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? StepDescription { get; set; }
        
        public DateTime ProgressDate { get; set; } = DateTime.Now;
        
        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, InProgress, Completed, Skipped
        
        public string Notes { get; set; } = string.Empty;
        
        public string Results { get; set; } = string.Empty;
        
        public DateTime? CompletedDate { get; set; }
        
        public int? RecordedByDoctorId { get; set; }
        
        // Navigation properties
        public virtual TreatmentRegistration TreatmentRegistration { get; set; } = null!;
        public virtual TreatmentStep? TreatmentStep { get; set; }
        public virtual Doctor? RecordedByDoctor { get; set; }
    }
}
