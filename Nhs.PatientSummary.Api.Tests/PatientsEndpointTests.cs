using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Nhs.PatientSummary.Api.Models;

namespace Nhs.PatientSummary.Api.Tests;

public class PatientsEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PatientsEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_patient_by_id_returns_404_when_patient_not_found()
    {
        // Act
        var response = await _client.GetAsync("/api/patients/999999");

        // Assert (HTTP behaviour)
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Get_patient_by_id_returns_200_when_patient_exists()
    {
        //Act
        var response = await _client.GetAsync("/api/patients/1");

        // Assert (HTTP behaviour)
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);


        // Deserialize payload and assert the returned patient data
        var patient = await response.Content.ReadFromJsonAsync<PatientDto>();
        Assert.NotNull(patient);
        Assert.Equal(1, patient!.Id);
        Assert.Equal("1234567890", patient!.NHSNumber);
        Assert.Equal("John Smith", patient!.Name);
    }
}