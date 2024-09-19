namespace MediPal.Components.Services
{
    //public class PatientService : IPatientService // PatientService inherits from IPatientService
    //{
    //    private readonly ApplicationDbContext _context;

    //    public PatientService(ApplicationDbContext context)
    //    {
    //        _context=context;
    //    }
    //    public async Task<List<Patient>> GetAllPatientsAsync()
    //    {
    //        await Task.Delay(1000);
    //        var symptoms = await _context.Patients.ToListAsync();
    //        return symptoms;
    //    }
    //    public async Task<Patient> GetPatientByIdAsync(int id)
    //    {
    //        var symptom = await _context.Patients.FindAsync(id);
    //        return symptom;
    //    }

    //    public async Task AddPatientAsync(Patient symptom)
    //    {
    //        _context.Patients.Add(symptom);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task DeletePatientAsync(int id)
    //    {
    //        var symptom = await _context.Patients.FindAsync(id);
    //        if (symptom != null)
    //        {
    //            _context.Patients.Remove(symptom);
    //            await _context.SaveChangesAsync();
    //        }
    //    }

    //    public async Task UpdatePatientAsync(Patient patient, int id)
    //    {
    //        var dbPatient = await _context.Patients.FindAsync(id);
    //        if (dbPatient != null)
    //        {
    //            dbPatient.PatientID = patient.PatientID;
    //            dbPatient.FirstName = patient.FirstName;
    //            dbPatient.LastName = patient.LastName;
    //            dbPatient.Gender = patient.Gender;
    //            dbPatient.DateOfBirth = patient.DateOfBirth;
    //            dbPatient.MedicalDiagnosis = patient.MedicalDiagnosis;
    //            dbPatient.Age = patient.Age;
    //            //dbPatient.Symptoms = patient.Symptoms;
    //            await _context.SaveChangesAsync();
    //        }
    //    }
    //}
}


