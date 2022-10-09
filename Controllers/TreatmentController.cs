using MeufarmaceuticoApi.Contracts.Requests;
using MeufarmaceuticoApi.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using MeufarmaceuticoApi.Repositories;
using FastEndpoints;


namespace MeufarmaceuticoApi.Controllers;

[ApiController]
[Route("{controller}/{id}")]
public class TreatmentController : ControllerBase
{

    private readonly ITreatmentRepository _TreatmentRepository;

    public TreatmentController(ITreatmentRepository treatmentRepository)
    {
        _TreatmentRepository = treatmentRepository;
    }

    public ActionResult HandleAsync()
    {
        try
        {
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
