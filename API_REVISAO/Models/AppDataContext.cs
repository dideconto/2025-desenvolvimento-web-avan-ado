using System;
using Microsoft.EntityFrameworkCore;

namespace API_REVISAO.Models;

public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    // public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");
    }
}
