using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNA.BussinessObject;

namespace DNA.Service
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(int doctorId);
        Task<Doctor> CreateDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorAsync(int doctorId);
        Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(string specialization);
        Task<IEnumerable<Doctor>> GetAvailableDoctorsAsync();
        Task<Doctor?> GetDoctorWithSchedulesAsync(int doctorId);
    }
}
