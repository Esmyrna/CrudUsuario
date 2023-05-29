using CrudUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUsuario.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios {get; set;}
        // Configurando mapeando da entidade do modelo para a tabela do db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             var usuario = modelBuilder.Entity<Usuario>();
             usuario.HasKey(x => x.Id);
             usuario.ToTable("tb_usuario");
             usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
             usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
             usuario.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
        }

    }
}