using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNA.BussinessObject;

namespace DNA.Service
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment?> GetAppointmentByIdAsync(int appointmentId);
        Task<Appointment> CreateAppointmentAsync(Appointment appointment);
        Task<Appointment> UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(int appointmentId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync();
        Task<bool> IsTimeSlotAvailableAsync(int doctorId, DateTime date, TimeSpan startTime, TimeSpan endTime);
    }
}
