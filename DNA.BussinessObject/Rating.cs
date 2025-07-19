using System;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        
        public int PatientId { get; set; }
        
        public int? DoctorId { get; set; }
        
        public int? ServiceId { get; set; }
        
        public int? RegistrationId { get; set; }
        
        public int RatingValue { get; set; } // 1-5 stars
        
        public string Comment { get; set; } = string.Empty;
        
        public string RatingType { get; set; } = string.Empty; // Doctor, Service, Overall
        
        public bool IsApproved { get; set; } = false;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime RatedDate { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor? Doctor { get; set; }
        public virtual TreatmentService? TreatmentService { get; set; }
        public virtual TreatmentRegistration? TreatmentRegistration { get; set; }
    }
}
