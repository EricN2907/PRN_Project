using System;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class DoctorSchedule
    {
        [Key]
        public int ScheduleId { get; set; }
        
        public int DoctorId { get; set; }
        
        public DayOfWeek DayOfWeek { get; set; }
        
        public TimeSpan StartTime { get; set; }
        
        public TimeSpan EndTime { get; set; }
        
        public bool IsAvailable { get; set; } = true;
        
        public DateTime? EffectiveFrom { get; set; }
        
        public DateTime? EffectiveTo { get; set; }
        
        // Navigation properties
        public virtual Doctor Doctor { get; set; } = null!;
    }
}
