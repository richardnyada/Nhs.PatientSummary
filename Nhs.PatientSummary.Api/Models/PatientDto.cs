namespace Nhs.PatientSummary.Api.Models
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string NHSNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string GPPractice { get; set; } = string.Empty;


    }
}
