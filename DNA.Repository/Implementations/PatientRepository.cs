using Microsoft.EntityFrameworkCore;
using DNA.BussinessObject;
using DNA.Repository.Interfaces;
using DNA.Repository.Implementations;

namespace DNA.Repository.Implementations
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Patient?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Patient?> GetByPhoneAsync(string phone)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Phone == phone);
        }

        public async Task<IEnumerable<Patient>> GetActivePlayersAsync()
        {
            return await _dbSet.Where(p => p.IsActive).ToListAsync();
        }
    }
}
