using MeufarmaceuticoApi.Contracts.Requests;
using MeufarmaceuticoApi.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using MeufarmaceuticoApi.Repositories;
using MeufarmaceuticoApi.Domain.Common;

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

    [HttpPost("/CreateTreatment")]
    public ActionResult CreateTreatment(Treatment treatment)
    {
        try
        {
            if(treatment is null)
               return BadRequest("Não existe nenhum tratamento");

            var treat = _TreatmentRepository.CreateTreatment();

            return Ok(treat);          
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
