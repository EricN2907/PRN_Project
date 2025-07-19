using Microsoft.EntityFrameworkCore;
using DNA.BussinessObject;
using DNA.Repository.Interfaces;
using DNA.Repository.Implementations;

namespace DNA.Repository.Implementations
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization)
        {
            return await _dbSet
                .Where(d => d.Specialization.Contains(specialization) && d.IsAvailable)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAvailableDoctorsAsync()
        {
            return await _dbSet
                .Where(d => d.IsAvailable)
                .Include(d => d.DoctorSchedules)
                .ToListAsync();
        }

        public async Task<Doctor?> GetWithSchedulesAsync(int doctorId)
        {
            return await _dbSet
                .Include(d => d.DoctorSchedules)
                .FirstOrDefaultAsync(d => d.DoctorId == doctorId);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsWithRatingAsync()
        {
            return await _dbSet
                .Include(d => d.Ratings)
                .Where(d => d.IsAvailable)
                .ToListAsync();
        }
    }
}
