using MediPal.Data;
using MediPal.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPal.Components.Services
{
    public class NoteService : INoteService // NoteService inherits from INoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<List<Note>> GetAllNotesAsync()
        {
            //await Task.Delay(500);
            var notes = await _context.Notes.ToListAsync();
            return notes;
        }

        // This is the method that gets all notes belonging to the specific userId
        public async Task<List<Note>> GetNotesByUserIdAsync(string userId)
        {
            //await Task.Delay(500);
            return await _context.Notes
                .Where(n => n.User.Id == userId)
                .ToListAsync();
        }

        // This is the method that gets all notes belonging to the specific patient being selected in the doctor's dashboard
        public async Task<List<Note>> GetNotesByPatientIdAsync(string patientId)
        {
            return await _context.Notes
                .Where(s => s.User.Id == patientId)
                .ToListAsync();
        }


        public async Task<Note> GetNoteByIdAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            return note;
        }

        public async Task AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(int id, string userId)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateNoteAsync(Note note, int id)
        {
            var dbNote = await _context.Notes.FindAsync(id);
            if (dbNote != null)
            {
                dbNote.NoteTitle = note.NoteTitle;
                dbNote.Date = note.Date;
                dbNote.NoteDescription = note.NoteDescription;
                await _context.SaveChangesAsync();
            }
        }
    }
}
