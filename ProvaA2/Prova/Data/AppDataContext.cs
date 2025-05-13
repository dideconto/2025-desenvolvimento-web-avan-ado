using System;
using Microsoft.EntityFrameworkCore;
using Prova.Models;

namespace Prova.Data;

public class AppDataContext : DbContext
{
    public AppDataContext
        (DbContextOptions<AppDataContext> options) 
        : base(options){   }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Evento> Eventos { get; set; }
}
