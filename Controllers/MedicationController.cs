using Microsoft.AspNetCore.Mvc;
using MeufarmaceuticoApi.Repositories;

namespace MeufarmaceuticoApi.ControlLers;

[Route("api/v1/[controller]")]
[ApiController]
public class MedicationController : ControllerBase
{
    private readonly IMedicationRepository _MedicationRepository;

    public MedicationController(IMedicationRepository medicationRepository)
    {
        _MedicationRepository = medicationRepository;
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult GetMedicationById(long id)
    {
        try
        {
            if (id == null)
                return BadRequest("Id obrigatório!");

            var medication = _MedicationRepository.GetMedicationById(id);

            return Ok(new { medication = medication });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult GetAllMedication()
    {
        try
        {
            var medication = _MedicationRepository.GetAllMedication();

            return Ok(new { medicationList = medication });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
