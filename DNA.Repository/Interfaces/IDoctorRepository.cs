using DNA.BussinessObject;
using DNA.Repository.Interfaces;

namespace DNA.Repository.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization);
        Task<IEnumerable<Doctor>> GetAvailableDoctorsAsync();
        Task<Doctor?> GetWithSchedulesAsync(int doctorId);
        Task<IEnumerable<Doctor>> GetDoctorsWithRatingAsync();
    }
}
