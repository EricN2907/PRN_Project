using DNA.BussinessObject;
using DNA.Repository.Interfaces;

namespace DNA.Repository.Interfaces
{
    public interface ITreatmentServiceRepository : IGenericRepository<TreatmentService>
    {
        Task<IEnumerable<TreatmentService>> GetByTreatmentTypeAsync(string treatmentType);
        Task<IEnumerable<TreatmentService>> GetActiveServicesAsync();
        Task<TreatmentService?> GetWithStepsAsync(int serviceId);
    }
}
