using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class TreatmentService
    {
        [Key]
        public int ServiceId { get; set; }
        
        [Required]
        public string ServiceName { get; set; } = string.Empty;
        
        public string ServiceCode { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string TreatmentType { get; set; } = string.Empty; // IUI, IVF, etc.
        
        public decimal Price { get; set; }
        
        public int DurationDays { get; set; }
        
        public string Requirements { get; set; } = string.Empty;
        
        public string Prerequisites { get; set; } = string.Empty;
        
        public string Contraindications { get; set; } = string.Empty;
        
        public double SuccessRate { get; set; }
        
        public string Procedure { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        public virtual ICollection<TreatmentRegistration> TreatmentRegistrations { get; set; } = new List<TreatmentRegistration>();
        public virtual ICollection<TreatmentStep> TreatmentSteps { get; set; } = new List<TreatmentStep>();
    }
}
