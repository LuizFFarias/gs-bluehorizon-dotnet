using gs_bluehorizon_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Data;

public class BlueHorizonDbContext : DbContext
{
    public DbSet<VoluntarioPessoa> VoluntarioPessoas { get; set; }
    public DbSet<VoluntarioPerfil> VoluntarioPerfils { get; set; }
    public DbSet<RecebimentoLixo> RecebimentoLixos { get; set; }
    public DbSet<PontosColeta> PontosColetas { get; set; }
    public DbSet<TiposLixo> TiposLixos { get; set; }
    public DbSet<SituacaoPraia> SituacaoPraias { get; set; }
    
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

        modelBuilder.Entity<VoluntarioPerfil>()
            .HasMany(e => e.RecebimentoLixos)
            .WithOne(e => e.VoluntarioPerfil)
            .HasForeignKey(e => e.PerfilId)
            .IsRequired(false);

        modelBuilder.Entity<VoluntarioPessoa>()
            .HasMany(e => e.RecebimentoLixos)
            .WithOne(e => e.VoluntarioPessoa)
            .HasForeignKey(e => e.PessoaId)
            .IsRequired(false);

        modelBuilder.Entity<PontosColeta>()
            .HasMany(e => e.RecebimentoLixos)
            .WithOne(e => e.PontosColeta)
            .HasForeignKey(e => e.PontosColetaId)
            .IsRequired(false);

        modelBuilder.Entity<RecebimentoLixo>()
            .HasMany(e => e.TiposLixos)
            .WithOne(e => e.RecebimentoLixo)
            .HasForeignKey(e => e.RecebimentoLixoId)
            .IsRequired(false);
    }
}