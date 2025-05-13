using System;

namespace Prova.Models;
public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public DateTime Data { get; set; } = DateTime.Now;
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public Usuario? Usuario { get; set; }
    public int? UsuarioId { get; set; }
}
