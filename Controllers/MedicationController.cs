using MeufarmaceuticoApi.Contracts.Requests;
using MeufarmaceuticoApi.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using MeufarmaceuticoApi.Repositories;
using FastEndpoints;

namespace MeufarmaceuticoApi.ControlLers;

[ApiController]
[Route("{controller}/{id}")]
public class MedicationController : ControllerBase
{
    private readonly IMedicationRepository _MedicationRepository;

    public MedicationController(IMedicationRepository medicationRepository)
    {
        _MedicationRepository = medicationRepository;
    }

    public override async Task HandleAsync(UpdateCustomerRequest req, CancellationToken ct)
    {
    
    }
}
