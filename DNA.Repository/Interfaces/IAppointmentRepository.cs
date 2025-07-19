using DNA.BussinessObject;
using DNA.Repository.Interfaces;

namespace DNA.Repository.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync();
        Task<bool> IsTimeSlotAvailableAsync(int doctorId, DateTime date, TimeSpan startTime, TimeSpan endTime);
    }
}
