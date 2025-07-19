using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DNA.BussinessObject;
using DNA.Repository;

namespace DNA.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            try
            {
                return await _context.Doctors
                    .OrderBy(d => d.FullName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving doctors: {ex.Message}", ex);
            }
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int doctorId)
        {
            try
            {
                return await _context.Doctors
                    .Include(d => d.DoctorSchedules)
                    .Include(d => d.TreatmentRegistrations)
                        .ThenInclude(tr => tr.Patient)
                    .Include(d => d.Appointments)
                        .ThenInclude(a => a.Patient)
                    .FirstOrDefaultAsync(d => d.DoctorId == doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving doctor with ID {doctorId}: {ex.Message}", ex);
            }
        }

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
        {
            try
            {
                // Validate email uniqueness
                var existingDoctor = await _context.Doctors
                    .FirstOrDefaultAsync(d => d.Email == doctor.Email);
                
                if (existingDoctor != null)
                {
                    throw new InvalidOperationException($"A doctor with email {doctor.Email} already exists.");
                }

                doctor.CreatedDate = DateTime.Now;
                doctor.IsAvailable = true;

                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();

                return doctor;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating doctor: {ex.Message}", ex);
            }
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            try
            {
                var existingDoctor = await _context.Doctors
                    .FirstOrDefaultAsync(d => d.DoctorId == doctor.DoctorId);

                if (existingDoctor == null)
                {
                    throw new InvalidOperationException($"Doctor with ID {doctor.DoctorId} not found.");
                }

                // Check email uniqueness (excluding current doctor)
                var emailExists = await _context.Doctors
                    .AnyAsync(d => d.Email == doctor.Email && d.DoctorId != doctor.DoctorId);

                if (emailExists)
                {
                    throw new InvalidOperationException($"A doctor with email {doctor.Email} already exists.");
                }

                // Update properties
                existingDoctor.FullName = doctor.FullName;
                existingDoctor.Email = doctor.Email;
                existingDoctor.Phone = doctor.Phone;
                existingDoctor.Specialization = doctor.Specialization;
                existingDoctor.Degree = doctor.Degree;
                existingDoctor.YearsOfExperience = doctor.YearsOfExperience;
                existingDoctor.LicenseNumber = doctor.LicenseNumber;
                existingDoctor.ConsultationFee = doctor.ConsultationFee;
                existingDoctor.Biography = doctor.Biography;
                existingDoctor.ImageUrl = doctor.ImageUrl;
                existingDoctor.IsAvailable = doctor.IsAvailable;
                existingDoctor.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return existingDoctor;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating doctor: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteDoctorAsync(int doctorId)
        {
            try
            {
                var doctor = await _context.Doctors
                    .FirstOrDefaultAsync(d => d.DoctorId == doctorId);

                if (doctor == null)
                {
                    return false;
                }

                // Soft delete - just mark as unavailable
                doctor.IsAvailable = false;
                doctor.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting doctor: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(string specialization)
        {
            try
            {
                return await _context.Doctors
                    .Where(d => d.Specialization.Contains(specialization) && d.IsAvailable)
                    .OrderBy(d => d.FullName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving doctors by specialization: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Doctor>> GetAvailableDoctorsAsync()
        {
            try
            {
                return await _context.Doctors
                    .Where(d => d.IsAvailable)
                    .OrderBy(d => d.FullName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving available doctors: {ex.Message}", ex);
            }
        }

        public async Task<Doctor?> GetDoctorWithSchedulesAsync(int doctorId)
        {
            try
            {
                return await _context.Doctors
                    .Include(d => d.DoctorSchedules)
                    .FirstOrDefaultAsync(d => d.DoctorId == doctorId && d.IsAvailable);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving doctor with schedules: {ex.Message}", ex);
            }
        }
    }
}
