using API_REVISAO.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddCors(options =>
    options.AddPolicy("Acesso total", 
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);
var app = builder.Build();

app.MapGet("/", () => "Revisão de Web API e EF!");

app.MapPost("/api/produto/cadastrar", 
    ([FromBody] Produto produto, 
    [FromServices] AppDataContext ctx) => 
{
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

app.MapGet("/api/produto/listar", 
    ([FromServices] AppDataContext ctx) => 
{
    return Results.Ok(ctx.Produtos.ToList());
});

app.UseCors("Acesso total");

app.Run();
