using MediPal.Models;

namespace MediPal.Components.Services
{
    public interface INoteService
    {
        Task<List<Note>> GetAllNotesAsync();
        Task<List<Note>> GetNotesByUserIdAsync(string userId); // This method gets all notes by ASPNETUserId, instead of just all notes
        Task<List<Note>> GetNotesByPatientIdAsync(string patientId); // This method gets all notes based on patientId
        Task<Note> GetNoteByIdAsync(int id);
        Task AddNoteAsync(Note note);
        Task UpdateNoteAsync(Note note, int id);
        Task DeleteNoteAsync(int id, string userId);
    }
}
