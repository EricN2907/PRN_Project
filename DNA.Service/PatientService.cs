using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DNA.BussinessObject;
using DNA.Repository;

namespace DNA.Service
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            try
            {
                return await _context.Patients
                    .OrderByDescending(p => p.CreatedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving patients: {ex.Message}", ex);
            }
        }

        public async Task<Patient?> GetPatientByIdAsync(int patientId)
        {
            try
            {
                return await _context.Patients
                    .Include(p => p.TreatmentRegistrations)
                        .ThenInclude(tr => tr.TreatmentService)
                    .Include(p => p.TreatmentRegistrations)
                        .ThenInclude(tr => tr.Doctor)
                    .Include(p => p.Appointments)
                    .FirstOrDefaultAsync(p => p.PatientId == patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving patient with ID {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            try
            {
                // Validate email uniqueness
                var existingPatient = await _context.Patients
                    .FirstOrDefaultAsync(p => p.Email == patient.Email);
                
                if (existingPatient != null)
                {
                    throw new InvalidOperationException($"A patient with email {patient.Email} already exists.");
                }

                patient.CreatedDate = DateTime.Now;
                patient.IsActive = true;

                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();

                return patient;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating patient: {ex.Message}", ex);
            }
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            try
            {
                var existingPatient = await _context.Patients
                    .FirstOrDefaultAsync(p => p.PatientId == patient.PatientId);

                if (existingPatient == null)
                {
                    throw new InvalidOperationException($"Patient with ID {patient.PatientId} not found.");
                }

                // Check email uniqueness (excluding current patient)
                var emailExists = await _context.Patients
                    .AnyAsync(p => p.Email == patient.Email && p.PatientId != patient.PatientId);

                if (emailExists)
                {
                    throw new InvalidOperationException($"A patient with email {patient.Email} already exists.");
                }

                // Update properties
                existingPatient.FullName = patient.FullName;
                existingPatient.DateOfBirth = patient.DateOfBirth;
                existingPatient.Gender = patient.Gender;
                existingPatient.Phone = patient.Phone;
                existingPatient.Email = patient.Email;
                existingPatient.Address = patient.Address;
                existingPatient.MedicalHistory = patient.MedicalHistory;
                existingPatient.EmergencyContact = patient.EmergencyContact;
                existingPatient.EmergencyPhone = patient.EmergencyPhone;
                existingPatient.BloodType = patient.BloodType;
                existingPatient.Allergies = patient.Allergies;
                existingPatient.IsActive = patient.IsActive;
                existingPatient.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return existingPatient;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating patient: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeletePatientAsync(int patientId)
        {
            try
            {
                var patient = await _context.Patients
                    .FirstOrDefaultAsync(p => p.PatientId == patientId);

                if (patient == null)
                {
                    return false;
                }

                // Soft delete - just mark as inactive
                patient.IsActive = false;
                patient.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting patient: {ex.Message}", ex);
            }
        }

        public async Task<Patient?> GetPatientByEmailAsync(string email)
        {
            try
            {
                return await _context.Patients
                    .FirstOrDefaultAsync(p => p.Email == email && p.IsActive);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving patient by email: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Patient>> GetActivePatientsAsync()
        {
            try
            {
                return await _context.Patients
                    .Where(p => p.IsActive)
                    .OrderByDescending(p => p.CreatedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving active patients: {ex.Message}", ex);
            }
        }
    }
}
