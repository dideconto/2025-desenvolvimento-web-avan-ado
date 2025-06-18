
namespace api_avaliacao.Models;

public class Comentario
{
    public int ComentarioId { get; set; }
    public string Texto { get; set; } = string.Empty;
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public Usuario? Usuario { get; set; }
    public int UsuarioId { get; set; }
}