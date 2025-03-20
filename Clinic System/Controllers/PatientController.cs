using Clinic_System.Models;
using Clinic_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;
        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient([FromForm] Patient patient)
        {
            await _patientService.RegisterPatient(patient);
            string formattedRecordId = patient.RecordId.ToString("D10");
            return CreatedAtAction(nameof(GetPatientByCPF), new { cpf = patient.CPF }, new { PatientId = formattedRecordId });
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetPatientByCPF([FromForm] string cpf)
        {
            var patient = await _patientService.GetPatientByCPF(cpf);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            return Ok(await _patientService.GetAllPatients());
        }

        [HttpPut("{cpf}")]
        public async Task<IActionResult> UpdatePatient(string cpf, [FromForm] Patient updatedPatient)
        {
            var patient = await _patientService.GetPatientByCPF(cpf);
            if (patient == null)
                return NotFound("Paciente não encontrado.");

            // Atualiza dados do paciente
            patient.Name = updatedPatient.Name;
            patient.Dateofbirth = updatedPatient.Dateofbirth;
            patient.Address = updatedPatient.Address;
            patient.Contact = updatedPatient.Contact;
            patient.BloodType = updatedPatient.BloodType;
            patient.Email = updatedPatient.Email;
            patient.MedicalHistory = updatedPatient.MedicalHistory;
            patient.Insurance = updatedPatient.Insurance;
            patient.Notes = updatedPatient.Notes;

            await _patientService.UpdatePatient(patient);
            return Ok("Dados do paciente atualizados com sucesso.");
        }

        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeletePatient(string cpf)
        {
            var patient = await _patientService.GetPatientByCPF(cpf);
            if (patient == null)
                return NotFound("Paciente não encontrado.");

            await _patientService.DeletePatient(cpf);
            return Ok("Paciente removido com sucesso.");
        }
    }
}