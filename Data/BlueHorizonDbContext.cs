using gs_bluehorizon_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Data;

public class BlueHorizonDbContext : DbContext
{
    public DbSet<VoluntarioPessoa> VoluntarioPessoas { get; set; }
    public DbSet<VoluntarioPerfil> VoluntarioPerfils { get; set; }
    
    public BlueHorizonDbContext(DbContextOptions<BlueHorizonDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VoluntarioPessoa>()
            .HasOne(e => e.Perfil)
            .WithOne(e => e.VoluntarioPessoa)
            .HasForeignKey<VoluntarioPerfil>(e => e.PessoaId)
            .IsRequired();
    }
}