using MediPal.Components.Models;
using MediPal.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MediPal.Components.Services
{
    public class PatientService : IPatientService
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public PatientService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetPatientByUserIdAsync(string userId)
        {
            var patient = await _userManager.FindByIdAsync(userId);

            if (patient != null && await _userManager.IsInRoleAsync(patient, "Patient"))
            {
                return patient;
            }

            return null;
        }

        public async Task<List<ApplicationUser>> GetAllPatientsAsync()
        {
            var patients = await _userManager.GetUsersInRoleAsync("Patient");
            return patients.ToList();
        }
    }
}

