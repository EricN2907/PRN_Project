using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNA.BussinessObject;

namespace DNA.Service
{
    public interface ITreatmentService
    {
        Task<IEnumerable<TreatmentService>> GetAllServicesAsync();
        Task<TreatmentService?> GetServiceByIdAsync(int serviceId);
        Task<TreatmentService> CreateServiceAsync(TreatmentService service);
        Task<TreatmentService> UpdateServiceAsync(TreatmentService service);
        Task<bool> DeleteServiceAsync(int serviceId);
        Task<IEnumerable<TreatmentService>> GetServicesByTypeAsync(string treatmentType);
        Task<TreatmentService?> GetServiceWithStepsAsync(int serviceId);
    }
}
