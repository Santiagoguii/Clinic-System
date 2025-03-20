using Clinic_System.Models;
using Clinic_System.Data;
using Microsoft.EntityFrameworkCore; // Adicionando a diretiva using correta
using static Clinic_System.Data.AppDbContext;

namespace Clinic_System.Services
{
    public class PatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task RegisterPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<Patient> GetPatientByCPF(string cpf)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.CPF == cpf);
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task UpdatePatient(Patient updatedPatient)
        {
            _context.Patients.Update(updatedPatient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(string cpf)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.CPF == cpf);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync(); 
            }
        }
    }
}