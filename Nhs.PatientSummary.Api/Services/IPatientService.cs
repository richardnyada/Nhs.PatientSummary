using Nhs.PatientSummary.Api.Models;

namespace Nhs.PatientSummary.Api.Services
{
    public interface IPatientService
    {
        PatientDto? GetById(int id);
    }
}
