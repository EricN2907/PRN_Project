using DNA.BussinessObject;
using DNA.Repository.Interfaces;

namespace DNA.Repository.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<Patient?> GetByEmailAsync(string email);
        Task<Patient?> GetByPhoneAsync(string phone);
        Task<IEnumerable<Patient>> GetActivePlayersAsync();
    }
}
