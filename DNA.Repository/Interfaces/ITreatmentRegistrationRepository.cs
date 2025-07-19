using DNA.BussinessObject;
using DNA.Repository.Interfaces;

namespace DNA.Repository.Interfaces
{
    public interface ITreatmentRegistrationRepository : IGenericRepository<TreatmentRegistration>
    {
        Task<IEnumerable<TreatmentRegistration>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<TreatmentRegistration>> GetByDoctorIdAsync(int doctorId);
        Task<IEnumerable<TreatmentRegistration>> GetByStatusAsync(string status);
        Task<TreatmentRegistration?> GetWithDetailsAsync(int registrationId);
    }
}
