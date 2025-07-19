using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNA.BussinessObject;

namespace DNA.Service
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient?> GetPatientByIdAsync(int patientId);
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<bool> DeletePatientAsync(int patientId);
        Task<Patient?> GetPatientByEmailAsync(string email);
        Task<IEnumerable<Patient>> GetActivePatientsAsync();
    }
}
