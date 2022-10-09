using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MeufarmaceuticoApi.Repositories;
using MeufarmaceuticoApi.Domain.Common;

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


    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Treatment>))]
    public ActionResult getALL(){

        // var produtos = _mapper.Map<ICollection<ProdutoDto>>(_produtosRepository.getALL());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(new Treatment());
    }


    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
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
