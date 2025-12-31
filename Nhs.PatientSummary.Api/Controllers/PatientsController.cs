using Microsoft.AspNetCore.Mvc;

namespace Nhs.PatientSummary.Api.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        /// <summary>
        /// GET /api/patients/{id}
        /// Honest placeholder: returns 501 Not Implemented.
        /// </summary>
        /// <param name="id">Patient identifier.</param>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var problem = new ProblemDetails
            {
                Status = StatusCodes.Status501NotImplemented,
                Title = "Not Implemented",
                Detail = "Patient summary endpoint is a stub and is not implemented yet."
            };

            return StatusCode(StatusCodes.Status501NotImplemented, problem);
        }
    }
}