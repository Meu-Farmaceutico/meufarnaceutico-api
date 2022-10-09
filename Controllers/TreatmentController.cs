using Microsoft.AspNetCore.Mvc;
using MeufarmaceuticoApi.Repositories;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TreatmentController : ControllerBase
{
    private readonly ITreatmentRepository _TreatmentRepository;

    public TreatmentController(ITreatmentRepository treatmentRepository)
    {
        _TreatmentRepository = treatmentRepository;
    }

    [Route("/CreateTreatment")]
    [HttpPost]
    public ActionResult CreateTreatment(Treatment treatment)
    {
        try
        {
            if(treatment is null)
               return BadRequest("Não existe nenhum tratamento");

            var treat = _TreatmentRepository.CreateTreatment(treatment);

            return Ok(treat);          
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
