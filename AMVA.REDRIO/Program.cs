using Microsoft.EntityFrameworkCore;
using AMVA.REDRIO.Infrastructure.Data;
using AMVA.REDRIO.Core.Repositories.Base;
using AMVA.REDRIO.Infrastructure.Repositories;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using AMVA.REDRIO.Core.DTO;


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
builder.Services.AddScoped<IRepository<Municipio>, MunicipioRepository>();
builder.Services.AddScoped<IRepository<TipoFase>, TipoFaseRepository>();
builder.Services.AddScoped<IRepository<Fase>, FaseRepository>();
builder.Services.AddScoped<IRepository<Campaña>, CampañaRepository>();
builder.Services.AddScoped<IRepository<ResultadoCampo>, ResultadoCampoRepository>();
builder.Services.AddScoped<IRepositoryReporteLaboratorio<ReportesLaboratorio>, ReportesLaboratorioRepository>();
builder.Services.AddScoped<IRepositoryEstacion<Estacion>, EstacionRepository>();
builder.Services.AddScoped<IRepository<Quimico>, QuimicoRepository>();
builder.Services.AddScoped<IRepository<Insitu>, InsituRepository>();
builder.Services.AddScoped<IRepository<Fisico>, FisicoRepository>();
builder.Services.AddScoped<IRepository<MetalAgua>, MetalAguaRepository>();
builder.Services.AddScoped<IRepository<Biologico>, BiologicoRepository>();
builder.Services.AddScoped<IRepository<Nutriente>, NutrienteRepository>();
builder.Services.AddScoped<IRepository<MetalSedimental>, MetalSedimentalRepository>();
builder.Services.AddScoped<IRepositoryHistorialExcel<HistorialExcel>, HistorialExcelRepository>();
builder.Services.AddScoped<IRepository<MuestraCompuesta>, MuestraCompuestaRepository>();
builder.Services.AddScoped<IRepository<TipoFuente>, TipoFuenteRepository>();
builder.Services.AddScoped<IRepository<Documento>, DocumentoRepository>();
builder.Services.AddScoped<IRepositoryDocsCampaña<DocsCampaña>, DocsCampañaRepository>();



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

// Configuración para servir archivos estáticos (como imágenes y documentos) desde la carpeta "wwwroot"
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
