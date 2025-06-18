using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_avaliacao.Data.Interfaces;
using api_avaliacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_avaliacao.Controllers;

[ApiController]
[Route("api/comentario")]
[Authorize]
public class ComentarioController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IComentarioRepository _comentarioRepository;
    public ComentarioController(IItemRepository itemRepository,
        IUsuarioRepository usuarioRepository,
        IComentarioRepository comentarioRepository)
    {
        _itemRepository = itemRepository;
        _usuarioRepository = usuarioRepository;
        _comentarioRepository = comentarioRepository;
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] Comentario comentario)
    {

        var item = _itemRepository.BuscarItemPorId(comentario.ItemId);
        string? email = User.Identity?.Name;
        Usuario? usuario = _usuarioRepository.BuscarUsuarioPorEmail(email!);
        comentario.Item = item;
        comentario.Usuario = usuario;
        _comentarioRepository.Cadastrar(comentario);
        return Created("", comentario);
    }
    [HttpGet("listar")]
    public IActionResult Listar()
    {
        return Ok(_comentarioRepository.Listar());
    }
    [HttpGet("buscarcomentariosporitem/{itemId}")]
    public IActionResult BuscarComentariosPorItem(int itemId)
    {
        return Ok(_comentarioRepository.BuscarComentariosPorItem(itemId));
    }

}