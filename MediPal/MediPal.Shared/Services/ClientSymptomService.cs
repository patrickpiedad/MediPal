using MediPal.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MediPal.Shared.Services
{
    public class ClientSymptomService : ISymptomService
    {
        private readonly HttpClient _httpClient;

        public ClientSymptomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Symptom>> GetAllSymptoms()
        {
            throw new NotImplementedException();
        }

        public async Task<Symptom> AddSymptom(Symptom symptom)
        {
            var result = await _httpClient
                .PostAsJsonAsync("api/symptom", symptom);
            return await result.Content.ReadFromJsonAsync<Symptom>();
        }

    }
}
