using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] Usuario usuario)
    {
        _usuarioRepository.Cadastrar(usuario);
        return Created("", usuario);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Usuario usuario)
    {
        Usuario? usuarioExistente = _usuarioRepository
            .BuscarUsuarioPorEmailSenha(usuario.Email, usuario.Senha);
        if(usuarioExistente == null)
            return Unauthorized(new { mensagem = "Usuário ou senha inválidos!"});

        return Ok(usuarioExistente);
    }

    [HttpGet("listar")]
    public IActionResult Listar()
    {        
        return Ok(_usuarioRepository.Listar());
    }


}