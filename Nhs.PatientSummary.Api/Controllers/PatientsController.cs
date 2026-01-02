using Microsoft.AspNetCore.Mvc;
using Nhs.PatientSummary.Api.Models;
using Nhs.PatientSummary.Api.Services;

namespace Nhs.PatientSummary.Api.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PatientDto> Get(int id)
        {
            var patient = _patientService.GetById(id);
            return patient is null ? NotFound() : Ok(patient);
        }
    }
}