using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Nhs.PatientSummary.Api;

namespace Nhs.PatientSummary.Api.Tests;

public class PatientsEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PatientsEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_patient_by_id_returns_501_not_implemented_for_stub()
    {
        // Act
        var response = await _client.GetAsync("/api/patients/1");

        // Assert (HTTP behaviour)
        Assert.Equal(HttpStatusCode.NotImplemented, response.StatusCode);

        // Assert (payload shape)
        var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        Assert.NotNull(problem);
        Assert.Equal((int)HttpStatusCode.NotImplemented, problem!.Status);
        Assert.Equal("Not Implemented", problem.Title);
    }
}
