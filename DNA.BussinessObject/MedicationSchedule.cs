using System;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class MedicationSchedule
    {
        [Key]
        public int MedicationId { get; set; }
        
        public int RegistrationId { get; set; }
        
        [Required]
        public string MedicationName { get; set; } = string.Empty;
        
        public string Dosage { get; set; } = string.Empty;
        
        public string Frequency { get; set; } = string.Empty;
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string Instructions { get; set; } = string.Empty;
        
        public string SideEffects { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual TreatmentRegistration TreatmentRegistration { get; set; } = null!;
    }
}
