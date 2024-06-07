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

        modelBuilder.Entity<RecebimentoLixo>()
            .HasMany(e => e.Perfils)
            .WithOne(e => e.RecebimentoLixo)
            .HasForeignKey(e => e.RecebimentoLixoId)
            .IsRequired(false);

        modelBuilder.Entity<RecebimentoLixo>()
            .HasMany(e => e.VoluntarioPessoas)
            .WithOne(e => e.RecebimentoLixo)
            .HasForeignKey(e => e.RecebimentoLixoId)
            .IsRequired(false);

        modelBuilder.Entity<RecebimentoLixo>()
            .HasMany(e => e.PontosColetas)
            .WithOne(e => e.RecebimentoLixo)
            .HasForeignKey(e => e.RecebimentoLixoId)
            .IsRequired(false);

        modelBuilder.Entity<RecebimentoLixo>()
            .HasMany(e => e.TiposLixos)
            .WithOne(e => e.RecebimentoLixo)
            .HasForeignKey(e => e.RecebimentoLixoId)
            .IsRequired(false);
    }
}