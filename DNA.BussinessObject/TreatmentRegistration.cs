using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class TreatmentRegistration
    {
        [Key]
        public int RegistrationId { get; set; }
        
        public int PatientId { get; set; }
        
        public int ServiceId { get; set; }
        
        public int DoctorId { get; set; }
        
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        public string Status { get; set; } = "Registered"; // Registered, InProgress, Completed, Cancelled
        
        public decimal TotalCost { get; set; }
        
        public decimal PaidAmount { get; set; } = 0;
        
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Partial, Paid
        
        public string Notes { get; set; } = string.Empty;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual TreatmentService TreatmentService { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual ICollection<TreatmentProgress> TreatmentProgresses { get; set; } = new List<TreatmentProgress>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<MedicationSchedule> MedicationSchedules { get; set; } = new List<MedicationSchedule>();
    }
}
