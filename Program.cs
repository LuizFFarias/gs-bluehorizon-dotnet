using gs_bluehorizon_dotnet.Data;
using gs_bluehorizon_dotnet.Repository;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVoluntarioPessoaRepository, VoluntarioPessoaRepository>();
builder.Services.AddScoped<IVoluntarioPerfilRepository, VoluntarioPerfilRepository>();
builder.Services.AddScoped<IRecebimentoLixoRepository, RecebimentoLixoRepository>();
builder.Services.AddScoped<IPontosColetaRepository, PontosColetaRepository>();
builder.Services.AddScoped<ITiposLixoRepository, TiposLixoRepository>();
builder.Services.AddScoped<ISituacaoPraiaRepository, SituacaoPraiaRepository>();

// Add DbContext Oracle on the project
builder.Services.AddDbContext<BlueHorizonDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleFiap"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();