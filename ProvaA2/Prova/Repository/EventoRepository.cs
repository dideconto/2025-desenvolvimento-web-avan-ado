using System;
using Microsoft.EntityFrameworkCore;
using Prova.Data;
using Prova.Models;
using Prova.Repository.Interfaces;

namespace Prova.Repository;

public class EventoRepository : IEventoRepository
{
    private readonly AppDataContext _context;
    public EventoRepository(AppDataContext context)
    {
        _context = context;
    }

    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public List<Evento> Listar()
    {
        return _context.Eventos.Include(x => x.Usuario).ToList();
    }

    public List<Evento> ListarPorUsuario(int id)
    {
        return _context.Eventos.Include(x => x.Usuario).Where(x => x.UsuarioId == id).ToList();
    }
}
