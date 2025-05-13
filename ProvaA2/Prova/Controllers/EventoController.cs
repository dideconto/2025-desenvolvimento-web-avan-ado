using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Prova.Data;
using Prova.Models;
using Prova.Repository;
using Prova.Repository.Interfaces;

namespace Prova.Controllers;

[ApiController]
[Route("api/evento")]
public class EventoController : ControllerBase
{
    // private readonly AppDataContext _context;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IEventoRepository _eventoRepository;
    // private readonly IConfiguration _configuration;
    public EventoController(IUsuarioRepository usuarioRepository,
        IEventoRepository eventoRepository)
        // AppDataContext context)
    {
        // _context = context;
        _eventoRepository = eventoRepository;
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost("cadastrar")]
    [Authorize]
    public IActionResult Cadastrar([FromBody] Evento evento)
    {
        string? email = User.Identity?.Name;
        Usuario? usuario = _usuarioRepository.BuscarPorEmail(email!);

        evento.Usuario = usuario;
        evento.UsuarioId = usuario!.Id;

        _eventoRepository.Cadastrar(evento);
        return Created("", evento);
    }
    

    [HttpGet("listar")]
    public IActionResult Listar()
    {             
        return Created("", _eventoRepository.Listar());
    }
    

    [HttpGet("usuario")]
    public IActionResult Usuario()
    {             
        string? email = User.Identity?.Name;
        Usuario? usuario = _usuarioRepository.BuscarPorEmail(email!);

        return Created("", _eventoRepository.ListarPorUsuario(usuario!.Id));
    }
}
