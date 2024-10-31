using Microsoft.EntityFrameworkCore;
using AMVA.REDRIO.Data;
using AMVA.REDRIO.Repositories;
using AMVA.REDRIO.Services;
using AMVA.REDRIO.Models; 
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnectionPru")));

// Configuración de CORS
builder.Services.AddCors(options => options.AddPolicy("AllowAll",
   builder =>
   {
       builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
   }));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuración de los servicios
builder.Services.AddScoped<IRepository<Departamento>, DepartamentoRepository>();
builder.Services.AddScoped<DepartamentoService>();
builder.Services.AddScoped<IRepository<Municipio>, MunicipioRepository>();
builder.Services.AddScoped<MunicipioService>();
builder.Services.AddScoped<IRepository<TipoFase>, TipoFaseRepository>();
builder.Services.AddScoped<TipoFaseService>();
builder.Services.AddScoped<IRepository<Fase>, FaseRepository>();
builder.Services.AddScoped<FaseService>();
builder.Services.AddScoped<IRepository<Campaña>, CampañaRepository>();
builder.Services.AddScoped<CampañaService>();
builder.Services.AddScoped<IRepository<ResultadoCampo>, ResultadoCampoRepository>();
builder.Services.AddScoped<ResultadoCampoService>();
builder.Services.AddScoped<IRepositoryReporteLaboratorio<ReportesLaboratorio>, ReportesLaboratorioRepository>();
builder.Services.AddScoped<ReportesLaboratorioService>();
builder.Services.AddScoped<IRepositoryEstacion<Estacion>, EstacionRepository>();
builder.Services.AddScoped<EstacionService>();
builder.Services.AddScoped<IRepository<Quimico>, QuimicoRepository>();
builder.Services.AddScoped<QuimicoService>();
builder.Services.AddScoped<IRepository<Insitu>, InsituRepository>();
builder.Services.AddScoped<InsituService>();
builder.Services.AddScoped<IRepository<Fisico>, FisicoRepository>();
builder.Services.AddScoped<FisicoService>();
builder.Services.AddScoped<IRepository<MetalAgua>, MetalAguaRepository>();
builder.Services.AddScoped<MetalAguaService>();
builder.Services.AddScoped<IRepository<Biologico>, BiologicoRepository>();
builder.Services.AddScoped<BiologicoService>();
builder.Services.AddScoped<IRepository<Nutriente>, NutrienteRepository>();
builder.Services.AddScoped<NutrienteService>();
builder.Services.AddScoped<IRepository<MetalSedimental>, MetalSedimentalRepository>();
builder.Services.AddScoped<MetalSedimentalService>();
builder.Services.AddScoped<IRepositoryHistorialExcel<HistorialExcel>, HistorialExcelRepository>();
builder.Services.AddScoped<HistorialExcelService>();
builder.Services.AddScoped<IRepository<MuestraCompuesta>, MuestraCompuestaRepository>();
builder.Services.AddScoped<MuestraCompuestaService>();
builder.Services.AddScoped<IRepository<TipoFuente>, TipoFuenteRepository>();
builder.Services.AddScoped<TipoFuenteService>();
builder.Services.AddScoped<IRepository<Documento>, DocumentoRepository>();
builder.Services.AddScoped<DocumentoService>();
builder.Services.AddScoped<IRepositoryDocsCampaña<DocsCampaña>, DocsCampañaRepository>();
builder.Services.AddScoped<DocsCampañaService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "wwwroot")),
    RequestPath = "/uploads"
});

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
