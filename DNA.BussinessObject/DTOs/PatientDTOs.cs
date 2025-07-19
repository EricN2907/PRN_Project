using System;

namespace DNA.BussinessObject.DTOs
{
    public class PatientCreateDTO
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
        public string EmergencyContact { get; set; } = string.Empty;
        public string EmergencyPhone { get; set; } = string.Empty;
        public string BloodType { get; set; } = string.Empty;
        public string Allergies { get; set; } = string.Empty;
    }

    public class PatientUpdateDTO : PatientCreateDTO
    {
        public int PatientId { get; set; }
        public bool IsActive { get; set; }
    }

    public class PatientListDTO
    {
        public int PatientId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        
        // DNA Testing specific properties
        public string DNATestStatus { get; set; } = "Chưa xét nghiệm"; // Chưa xét nghiệm, Đang xét nghiệm, Hoàn thành, Đã hủy
        public int TotalDNATests { get; set; } = 0;
        public int CompletedDNATests { get; set; } = 0;
        public DateTime? LastDNATestDate { get; set; }
        public string Status => IsActive ? "Đang hoạt động" : "Không hoạt động";
    }
}
