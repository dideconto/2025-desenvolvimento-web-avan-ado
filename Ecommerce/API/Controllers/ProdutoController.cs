using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private readonly AppDataContext _context;
    public ProdutoController(AppDataContext context)
    {
        _context = context;
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar
        ([FromBody] Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return Created("", produto);
    }

    //Exemplo de método dentro de uma classe
    [HttpGet]
    public string Metodo()
    {
        return "";
    }

    //Exemplo de um EndPoint dentro de um Controller
    [HttpGet("helloworld")]
    public IActionResult HelloWorld()
    {
        return Ok("Hello World!");
    }
}