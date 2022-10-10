using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MeufarmaceuticoApi.Repositories;
using MeufarmaceuticoApi.Domain.Common;
using System.Text.Json;

namespace MeufarmaceuticoApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TreatmentController : ControllerBase
{
    private readonly ITreatmentRepository _TreatmentRepository;

    public TreatmentController(ITreatmentRepository treatmentRepository)
    {
        _TreatmentRepository = treatmentRepository;
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult CreateTreatment(Treatment treatment)
    {
        try
        {
            if (treatment is null)
                return BadRequest("Não existe nenhum tratamento");

            var treat = _TreatmentRepository.CreateTreatment(treatment);

            var result = JsonSerializer.Serialize(treat);

            return Ok( new { treatment = result });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult GetTreatmentById(long id)
    {
        try
        {
            var result = _TreatmentRepository.GetTreatmentById(id);

            var resultJson = JsonSerializer.Serialize(result);

            return Ok(new { treatment = resultJson });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult GetTreatmentList()
    {
        try
        {
            var treatment = _TreatmentRepository.GetTreatmentList();

            var resultJson = JsonSerializer.Serialize(treatment);

            return Ok(new { treatment = resultJson });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult UpdateTreatment(Treatment treatment, long Id)
    {
        try
        {
            if (treatment.TreatmentId != Id)
                return BadRequest("Ids diferentes!");

            var treatmentResult = _TreatmentRepository.UpdateTreatment(treatment);

            var resultJson = JsonSerializer.Serialize(treatmentResult);

            return Ok(new { treatment = resultJson });
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult DeleteTreatment(long Id)
    {
        try
        {
            if (Id == null)
                return BadRequest("Necessita de um Id!");

            var treatment = _TreatmentRepository.DeleteTreatment(Id);

            var resultJson = JsonSerializer.Serialize(treatment);

            return Ok(new { treatment = resultJson });
        }
        catch(Exception ex) 
        {
            return BadRequest(ex.Message);
        }
    }
}
