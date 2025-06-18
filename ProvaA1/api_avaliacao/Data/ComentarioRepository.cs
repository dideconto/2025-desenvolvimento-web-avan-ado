using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_avaliacao.Data.Interfaces;
using api_avaliacao.Models;
using Microsoft.EntityFrameworkCore;

namespace api_avaliacao.Data;

public class ComentarioRepository : IComentarioRepository
{
    private readonly AppDataContext _context;
    public ComentarioRepository(AppDataContext context)
    {
        _context = context;
    }
    public List<Comentario>? BuscarComentariosPorItem(int id)
    {
        return _context.Comentarios
            .Include(x => x.Item)
            .Include(x => x.Usuario)
            .Where(c => c.ItemId == id)
            .OrderByDescending(c => c.CriadoEm)
            .ToList();
    }

    public void Cadastrar(Comentario comentario)
    {
        _context.Comentarios.Add(comentario);
        _context.SaveChanges();
    }

    public List<Comentario> Listar()
    {
        return _context.Comentarios
            .Include(x => x.Item)
            .Include(x => x.Usuario)
            .OrderByDescending(c => c.CriadoEm)
            .ToList();
    }
}