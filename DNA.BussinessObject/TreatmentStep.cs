using System;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class TreatmentStep
    {
        [Key]
        public int StepId { get; set; }
        
        public int ServiceId { get; set; }
        
        [Required]
        public string StepName { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public int StepOrder { get; set; }
        
        public int DurationDays { get; set; }
        
        public string Instructions { get; set; } = string.Empty;
        
        public bool IsRequired { get; set; } = true;
        
        // Navigation properties
        public virtual TreatmentService TreatmentService { get; set; } = null!;
    }
}
