using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNA.BussinessObject;

namespace DNA.Service
{
    public interface ITreatmentRegistrationService
    {
        Task<IEnumerable<TreatmentRegistration>> GetAllRegistrationsAsync();
        Task<TreatmentRegistration?> GetRegistrationByIdAsync(int registrationId);
        Task<TreatmentRegistration> CreateRegistrationAsync(TreatmentRegistration registration);
        Task<TreatmentRegistration> UpdateRegistrationAsync(TreatmentRegistration registration);
        Task<bool> DeleteRegistrationAsync(int registrationId);
        Task<IEnumerable<TreatmentRegistration>> GetRegistrationsByPatientAsync(int patientId);
        Task<IEnumerable<TreatmentRegistration>> GetRegistrationsByDoctorAsync(int doctorId);
        Task<TreatmentRegistration?> GetRegistrationWithDetailsAsync(int registrationId);
    }
}
