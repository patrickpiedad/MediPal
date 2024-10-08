using MediPal.Components.Services;
using MediPal.Data;
using MediPal.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DoctorService : IDoctorService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public DoctorService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<ApplicationUser>> GetAllDoctorsAsync()
    {
        var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
        return doctors.ToList();
    }
}