using System;
using Prova.Data;
using Prova.Models;
using Prova.Repository.Interfaces;

namespace Prova.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDataContext _context;
    public UsuarioRepository(AppDataContext context)
    {
        _context = context;
    }

    public Usuario? BuscarPorEmail(string email)
    {
        return _context.Usuarios.
            FirstOrDefault(x => x.Email == email);
    }

    public Usuario? BuscarPorEmailSenha(string email, string senha)
    {
        return _context.Usuarios.
            FirstOrDefault(x => x.Email == email && 
            x.Senha == senha);
    }

    public void Cadastrar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public List<Usuario> Listar()
    {
        return _context.Usuarios.ToList();
    }
}
