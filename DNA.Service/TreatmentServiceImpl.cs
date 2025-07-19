using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DNA.BussinessObject;
using DNA.Repository;

namespace DNA.Service
{
    public class TreatmentServiceImpl : ITreatmentService
    {
        private readonly ApplicationDbContext _context;

        public TreatmentServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TreatmentService>> GetAllServicesAsync()
        {
            try
            {
                return await _context.DNATestServices
                    .Where(ts => ts.IsActive)
                    .OrderBy(ts => ts.ServiceName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving treatment services: {ex.Message}", ex);
            }
        }

        public async Task<TreatmentService?> GetServiceByIdAsync(int serviceId)
        {
            try
            {
                return await _context.DNATestServices
                    .Include(ts => ts.TreatmentSteps)
                    .Include(ts => ts.TreatmentRegistrations)
                        .ThenInclude(tr => tr.Patient)
                    .FirstOrDefaultAsync(ts => ts.ServiceId == serviceId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving treatment service with ID {serviceId}: {ex.Message}", ex);
            }
        }

        public async Task<TreatmentService> CreateServiceAsync(TreatmentService service)
        {
            try
            {
                // Validate service code uniqueness
                var existingService = await _context.DNATestServices
                    .FirstOrDefaultAsync(ts => ts.ServiceCode == service.ServiceCode);
                
                if (existingService != null)
                {
                    throw new InvalidOperationException($"A service with code {service.ServiceCode} already exists.");
                }

                service.CreatedDate = DateTime.Now;
                service.IsActive = true;

                _context.DNATestServices.Add(service);
                await _context.SaveChangesAsync();

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating treatment service: {ex.Message}", ex);
            }
        }

        public async Task<TreatmentService> UpdateServiceAsync(TreatmentService service)
        {
            try
            {
                var existingService = await _context.DNATestServices
                    .FirstOrDefaultAsync(ts => ts.ServiceId == service.ServiceId);

                if (existingService == null)
                {
                    throw new InvalidOperationException($"Treatment service with ID {service.ServiceId} not found.");
                }

                // Check service code uniqueness (excluding current service)
                var codeExists = await _context.DNATestServices
                    .AnyAsync(ts => ts.ServiceCode == service.ServiceCode && ts.ServiceId != service.ServiceId);

                if (codeExists)
                {
                    throw new InvalidOperationException($"A service with code {service.ServiceCode} already exists.");
                }

                // Update properties
                existingService.ServiceCode = service.ServiceCode;
                existingService.ServiceName = service.ServiceName;
                existingService.Description = service.Description;
                existingService.TreatmentType = service.TreatmentType;
                existingService.Price = service.Price;
                existingService.DurationDays = service.DurationDays;
                existingService.Prerequisites = service.Prerequisites;
                existingService.Contraindications = service.Contraindications;
                existingService.SuccessRate = service.SuccessRate;
                existingService.IsActive = service.IsActive;
                existingService.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return existingService;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating treatment service: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteServiceAsync(int serviceId)
        {
            try
            {
                var service = await _context.DNATestServices
                    .FirstOrDefaultAsync(ts => ts.ServiceId == serviceId);

                if (service == null)
                {
                    return false;
                }

                // Soft delete - just mark as inactive
                service.IsActive = false;
                service.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting treatment service: {ex.Message}", ex);
            }
        }


        public async Task<IEnumerable<TreatmentService>> GetServicesByTypeAsync(string treatmentType)
        {
            try
            {
                return await _context.DNATestServices
                    .Where(ts => ts.TreatmentType == treatmentType && ts.IsActive)
                    .OrderBy(ts => ts.ServiceName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving services by type: {ex.Message}", ex);
            }
        }

        public async Task<TreatmentService?> GetServiceWithStepsAsync(int serviceId)
        {
            try
            {
                return await _context.DNATestServices
                    .Include(ts => ts.TreatmentSteps.OrderBy(step => step.StepOrder))
                    .FirstOrDefaultAsync(ts => ts.ServiceId == serviceId && ts.IsActive);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving service with steps: {ex.Message}", ex);
            }
        }
    }
}
