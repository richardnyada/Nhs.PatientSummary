using System;
using System.Collections.Generic;
using System.Linq;
using Nhs.PatientSummary.Api.Models;

namespace Nhs.PatientSummary.Api.Services
{
    public class InMemoryPatientService : IPatientService
    {
        private static readonly PatientDto[] Patients = new[]
        {
            new PatientDto
            {
                Id = 1,
                NHSNumber = "1234567890",
                Name = "John Smith",
                DateOfBirth = new DateTime(1985, 3, 12),
                GPPractice = "Northumbria Medical Centre"
            },
            new PatientDto
            {
                Id = 2,
                NHSNumber = "9876543210",
                Name = "Sarah Jones",
                DateOfBirth = new DateTime(1990, 7, 22),
                GPPractice = "Seaton Delaval Surgery"
            },
            new PatientDto
            {
                Id = 3,
                NHSNumber = "4567891230",
                Name = "Michael Brown",
                DateOfBirth = new DateTime(1978, 11, 5),
                GPPractice = "Tyne Health Practice"
            }
        };

        public PatientDto? GetById(int id) => Patients.FirstOrDefault(p => p.Id == id);
    }
}
