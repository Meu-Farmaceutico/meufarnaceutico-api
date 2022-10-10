using MeufarmaceuticoApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeufarmaceuticoApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _UserRepository;

    public UserController(IUserRepository userRepository)
    {
        _UserRepository = userRepository;   
    }

    [HttpGet]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult GetUserById(long Id)
    {
        try
        {
            if (Id == null)
                return BadRequest($"Necessário um {Id}");

            var user = _UserRepository.GetUserById(Id);

            return Ok(new {user = user});
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
