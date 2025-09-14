using GestorMecanicaAPI.Exceptions;
using GestorMecanicaAPI.Model;
using GestorMecanicaAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorMecanicaAPI.Controllers;

[ApiController]
[AllowAnonymous]
[Route("mecanica")]
public class MecanicaController : ControllerBase
{

    private readonly PecaService _pecaService;

    public MecanicaController(PecaService pecaService)
    {
        _pecaService = pecaService;
    }

    [HttpPost]
    [Route("/Gravar")]
    public ActionResult CadastraPeca([FromBody] PecaModel pecaModel)
    {

        try
        {
            _pecaService.CadastraPeca(pecaModel);
            return Ok("Peça cadastrada com sucesso");
        }
        catch (BusinessException bs)
        {
            return StatusCode(400, bs.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro interno");
        }
    }


}
