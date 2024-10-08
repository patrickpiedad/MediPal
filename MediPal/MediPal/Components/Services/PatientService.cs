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

        // Retrieve a specific patient by their User ID
        public async Task<ApplicationUser> GetPatientByUserIdAsync(string userId)
        {
            return await _userManager.Users.FirstOrDefaultAsync(user => user.Id == userId && _userManager.IsInRoleAsync(user, "Patient").Result);
        }

        // Retrieve all users with the role of "Patient"
        public async Task<List<ApplicationUser>> GetAllPatientsAsync()
        {
            var patients = await _userManager.GetUsersInRoleAsync("Patient");
            return patients.ToList();
        }
    }
}
