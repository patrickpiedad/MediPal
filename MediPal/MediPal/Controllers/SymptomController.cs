using MediPal.Shared.Models;
using MediPal.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediPal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomController : ControllerBase
    {
        private readonly ISymptomService _symptomService;
        public SymptomController(ISymptomService symptomService)
        {
            _symptomService = symptomService;
        }

        [HttpPost]
        public async Task <ActionResult<Symptom>> AddSymptom(Symptom symptom)
        {
            var addedSymptom = await _symptomService.AddSymptom(symptom);
            return Ok(addedSymptom);
        }
    }
}
