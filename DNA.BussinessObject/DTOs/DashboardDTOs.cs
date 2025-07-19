using System;

namespace DNA.BussinessObject.DTOs
{
    public class DashboardStatisticsDTO
    {
        public int TotalPatients { get; set; }
        public int ActiveTreatments { get; set; }
        public int TodayAppointments { get; set; }
        public int AvailableDoctors { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public int CompletedTreatments { get; set; }
        public double SuccessRate { get; set; }
    }

    public class RecentActivityDTO
    {
        public DateTime Time { get; set; }
        public string Activity { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }

    public class UpcomingAppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string AppointmentType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
