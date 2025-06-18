
using api_avaliacao.Models;

namespace api_avaliacao.Data.Interfaces;

public interface IComentarioRepository
{
    void Cadastrar(Comentario comentario);
    List<Comentario> Listar();
    List<Comentario>? BuscarComentariosPorItem(int id);

};