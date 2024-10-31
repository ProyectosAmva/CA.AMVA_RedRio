using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AMVA.REDRIO.Data;
using AMVA.REDRIO.Models;

namespace AMVA.REDRIO.Repositories
{
    //Departamento
    public class DepartamentoRepository : IRepository<Departamento>
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetByIdAsync(int id)
        {
            return await _context.Departamentos.FindAsync(id);
        }

        public async Task AddAsync(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departamento departamento)
        {
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
                await _context.SaveChangesAsync();
            }
        }
    }
//Municipio
    public class MunicipioRepository : IRepository<Municipio>
    {
        private readonly ApplicationDbContext _context;

        public MunicipioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

         public async Task<IEnumerable<Municipio>> GetAllAsync()
        {
            return await _context.Municipios
                .Include(m => m.Departamento)  
                .ToListAsync();
        }

        public async Task<Municipio> GetByIdAsync(int id)
        {
            return await _context.Municipios
                .Include(m => m.Departamento)  
                .FirstOrDefaultAsync(m => m.IdMunicipio == id);
        }

        public async Task AddAsync(Municipio municipio)
        {
            _context.Municipios.Add(municipio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Municipio municipio)
        {
            _context.Municipios.Update(municipio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio != null)
            {
                _context.Municipios.Remove(municipio);
                await _context.SaveChangesAsync();
            }
        }
    }
//TipoFase
    public class TipoFaseRepository : IRepository<TipoFase>
{
    private readonly ApplicationDbContext _context;

    public TipoFaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TipoFase>> GetAllAsync()
    {
        return await _context.TipoFases.ToListAsync();
    }

    public async Task<TipoFase> GetByIdAsync(int id)
    {
        return await _context.TipoFases.FindAsync(id);
    }

    public async Task AddAsync(TipoFase tipoFase)
    {
        _context.TipoFases.Add(tipoFase);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TipoFase tipoFase)
    {
        _context.TipoFases.Update(tipoFase);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tipoFase = await _context.TipoFases.FindAsync(id);
        if (tipoFase != null)
        {
            _context.TipoFases.Remove(tipoFase);
            await _context.SaveChangesAsync();
        }
    }
}
    
//TipoFuente
    public class TipoFuenteRepository : IRepository<TipoFuente>
{
    private readonly ApplicationDbContext _context;

    public TipoFuenteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TipoFuente>> GetAllAsync()
    {
        return await _context.TipoFuentes.ToListAsync();
    }

    public async Task<TipoFuente> GetByIdAsync(int id)
    {
        return await _context.TipoFuentes.FindAsync(id);
    }

    public async Task AddAsync(TipoFuente tipoFuente)
    {
        _context.TipoFuentes.Add(tipoFuente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TipoFuente tipoFuente)
    {
        _context.TipoFuentes.Update(tipoFuente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tipoFuente = await _context.TipoFuentes.FindAsync(id);
        if (tipoFuente != null)
        {
            _context.TipoFuentes.Remove(tipoFuente);
            await _context.SaveChangesAsync();
        }
    }
}
  
    //Fases
    public class FaseRepository : IRepository<Fase>
{
    private readonly ApplicationDbContext _context;

    public FaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Fase>> GetAllAsync()
    {
         return await _context.Fases
                .Include(m => m.TipoFase)  
                .ToListAsync();

    }

    public async Task<Fase> GetByIdAsync(int id)
    {
        return await _context.Fases
                .Include(m => m.TipoFase)  
                .FirstOrDefaultAsync(m => m.IdFase == id);
    }

    public async Task AddAsync(Fase fase)
    {
        _context.Fases.Add(fase);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Fase fase)
    {
        _context.Fases.Update(fase);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var fase = await _context.Fases.FindAsync(id);
        if (fase != null)
        {
            _context.Fases.Remove(fase);
            await _context.SaveChangesAsync();
        }
    }
}

//Campañas
    public class CampañaRepository : IRepository<Campaña>
{
    private readonly ApplicationDbContext _context;

    public CampañaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Campaña>> GetAllAsync()
        {
            return await _context.Campañas
                .Include(c => c.Fase)  
                .ToListAsync();
        }

        public async Task<Campaña> GetByIdAsync(int id)
        {
            return await _context.Campañas
                .Include(c => c.Fase)  
                .FirstOrDefaultAsync(c => c.IdCampaña == id);
        }
    public async Task AddAsync(Campaña campaña)
    {
        _context.Campañas.Add(campaña);  
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Campaña campaña)
    {
        _context.Campañas.Update(campaña);  
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var campaña = await _context.Campañas.FindAsync(id);
        if (campaña != null)
        {
            _context.Campañas.Remove(campaña);
            await _context.SaveChangesAsync();
        }
    }
}

//Resultado_campo
 public class ResultadoCampoRepository : IRepository<ResultadoCampo>

 
{
    private readonly ApplicationDbContext _context;

    public ResultadoCampoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ResultadoCampo>> GetAllAsync()
    {
        return await _context.ResultadoCampos.ToListAsync();
    }

    public async Task<ResultadoCampo> GetByIdAsync(int id)
    {
        return await _context.ResultadoCampos.FindAsync(id);
    }

    public async Task AddAsync(ResultadoCampo resultadoCampo)
    {
        _context.ResultadoCampos.Add(resultadoCampo);  
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ResultadoCampo resultadoCampo)
    {
        _context.ResultadoCampos.Update(resultadoCampo);  
        await _context.SaveChangesAsync();
    }

   public async Task DeleteAsync(int id)
    {
        var resultadoCampo = await _context.ResultadoCampos.FindAsync(id);
        if (resultadoCampo != null)
        {
            _context.ResultadoCampos.Remove(resultadoCampo); 
            await _context.SaveChangesAsync();
        }
    }

}

// reporte laboratorio
public class ReportesLaboratorioRepository : IRepositoryReporteLaboratorio<ReportesLaboratorio>

{
    private readonly ApplicationDbContext _context;

    public ReportesLaboratorioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

     public async Task<IEnumerable<ReportesLaboratorio>> GetAllAsync()
        {
            return await _context.ReportesLaboratorios
                .Include(r => r.Campaña)         
        .Include(r => r.ResultadoCampo)  
        .Include(r => r.MuestraCompuesta)
            .ThenInclude(m => m.Insitu)         
        .Include(r => r.MuestraCompuesta)
            .ThenInclude(m => m.Nutriente)      
        .Include(r => r.MuestraCompuesta)
            .ThenInclude(m => m.Quimico)        
        .Include(r => r.MuestraCompuesta)
            .ThenInclude(m => m.Fisico)         
        .Include(r => r.MuestraCompuesta)
            .ThenInclude(m => m.MetalAgua)      
        .Include(r => r.MuestraCompuesta)
            .ThenInclude(m => m.MetalSedimental) 
        .Include(r => r.MuestraCompuesta)
            .ThenInclude(m => m.Biologico)                     
        .Include(r => r.Estacion)               // Asegúrate de que `Estacion` está correctamente referenciado
            .ThenInclude(e => e.Municipio)      // Aquí corregí el error de acceso
        .Include(r => r.Estacion)               // Si `TipoFuente` también es parte de `Estacion`, entonces está bien
            .ThenInclude(e => e.TipoFuente)      // Corregido para usar `tipoFuente`
        .ToListAsync();
        }

        public async Task<ReportesLaboratorio> GetByIdAsync(int id)
        {
            return await _context.ReportesLaboratorios
                .Include(r => r.Campaña)         
                .Include(r => r.ResultadoCampo) 
                .Include(r => r.Estacion)  
            .Include(r => r.MuestraCompuesta)
            .ThenInclude(m => m.Insitu)         
            .Include(r => r.MuestraCompuesta)
             .ThenInclude(m => m.Nutriente)      
                    .Include(r => r.MuestraCompuesta)
                        .ThenInclude(m => m.Quimico)        
                    .Include(r => r.MuestraCompuesta)
                        .ThenInclude(m => m.Fisico)         
                    .Include(r => r.MuestraCompuesta)
                        .ThenInclude(m => m.MetalAgua)      
                    .Include(r => r.MuestraCompuesta)
                        .ThenInclude(m => m.MetalSedimental) 
                    .Include(r => r.MuestraCompuesta)
                        .ThenInclude(m => m.Biologico)     
                            .FirstOrDefaultAsync(r => r.IdReporte == id);
        }
        
          public async Task<IEnumerable<ReportesLaboratorio>> GetByCampañaAsync(int IdCampaña)
        {
            return await _context.ReportesLaboratorios
                .Include(r => r.Campaña)         
                .Include(r => r.ResultadoCampo) 
                .Include(r => r.Estacion)  
                .Include(r => r.MuestraCompuesta)
                    .ThenInclude(m => m.Insitu)         
                .Include(r => r.MuestraCompuesta)
                    .ThenInclude(m => m.Nutriente)      
                .Include(r => r.MuestraCompuesta)
                    .ThenInclude(m => m.Quimico)        
                .Include(r => r.MuestraCompuesta)
                    .ThenInclude(m => m.Fisico)         
                .Include(r => r.MuestraCompuesta)
                    .ThenInclude(m => m.MetalAgua)      
                .Include(r => r.MuestraCompuesta)
                    .ThenInclude(m => m.MetalSedimental) 
                .Include(r => r.MuestraCompuesta)
                    .ThenInclude(m => m.Biologico)
                .Include(r => r.Estacion) 
                    .ThenInclude(m => m.Municipio) 
                .Include(r => r.Estacion)  
                    .ThenInclude(m=> m.TipoFuente)     
                .Where(c => c.IdCampaña == IdCampaña)
                

                .ToListAsync();
        }


    public async Task AddAsync(ReportesLaboratorio reportesLaboratorio)
    {
        _context.ReportesLaboratorios.Add(reportesLaboratorio);  
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ReportesLaboratorio reportesLaboratorio)
    {
        _context.ReportesLaboratorios.Update(reportesLaboratorio);  
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var reportesLaboratorio = await _context.ReportesLaboratorios.FindAsync(id); 
        if (reportesLaboratorio != null)
        {
            _context.ReportesLaboratorios.Remove(reportesLaboratorio); 
            await _context.SaveChangesAsync();
        }
    }

        public Task<ReportesLaboratorio> GetByCodigoAsync(string IdCampaña)
        {
            throw new NotImplementedException();
        }

        public Task<ReportesLaboratorio> GetByCampañaAsync(string IdCampaña)
        {
            throw new NotImplementedException();
        }
    }


//Muestra compuesta 
public class MuestraCompuestaRepository : IRepository<MuestraCompuesta>
{
    private readonly ApplicationDbContext _context;

    public MuestraCompuestaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

     public async Task<IEnumerable<MuestraCompuesta>> GetAllAsync()
        {
            return await _context.MuestraCompuestas
                .Include(r => r.Insitu)  
                .Include(r => r.Nutriente)  
                .Include(r => r.Quimico)  
                .Include(r => r.Fisico)  
                .Include(r => r.MetalAgua)  
                .Include(r => r.Biologico)  
                .Include(r => r.MetalSedimental)  

                .ToListAsync();
        }

        public async Task<MuestraCompuesta> GetByIdAsync(int id)
        {
            return await _context.MuestraCompuestas
                .Include(r => r.Insitu)  
                .Include(r => r.Nutriente)  
                .Include(r => r.Quimico)  
                .Include(r => r.Fisico)  
                .Include(r => r.MetalAgua)  
                .Include(r => r.Biologico)  
                .Include(r => r.MetalSedimental)  

                .FirstOrDefaultAsync(r => r.IdMuestraCompuesta == id);
        }

    public async Task AddAsync(MuestraCompuesta muestraCompuesta)
    {
        _context.MuestraCompuestas.Add(muestraCompuesta);  
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MuestraCompuesta muestraCompuesta)
    {
        _context.MuestraCompuestas.Update(muestraCompuesta);  
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var MuestraCompuesta = await _context.MuestraCompuestas.FindAsync(id); 
        if (MuestraCompuesta != null)
        {
            _context.MuestraCompuestas.Remove(MuestraCompuesta); 
            await _context.SaveChangesAsync();
        }
    }
}


//Estacion
public class EstacionRepository : IRepositoryEstacion<Estacion>
{
    private readonly ApplicationDbContext _context;

    public EstacionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
     public async Task<Estacion> GetByCodigoAsync(string codigo) 
    {
        return await _context.Estaciones
            .Include(c => c.Municipio)
            .Include(c => c.TipoFuente)
            .FirstOrDefaultAsync(e => e.codigo == codigo) ;
    }

    public async Task<IEnumerable<Estacion>> GetAllAsync()
        {
            return await _context.Estaciones
                .Include(c => c.Municipio)  
                .Include(c => c.TipoFuente)
                .ToListAsync();
        }

        public async Task<Estacion> GetByIdAsync(int id)
        {
            return await _context.Estaciones
                .Include(c => c.Municipio)  
                .FirstOrDefaultAsync(c => c.IdEstacion == id);
        }

    public async Task AddAsync(Estacion estacion)
    {
        _context.Estaciones.Add(estacion);  
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Estacion estacion)
    {
        _context.Estaciones.Update(estacion);  
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var estacion = await _context.Estaciones.FindAsync(id);
        if (estacion != null)
        {
            _context.Estaciones.Remove(estacion);
            await _context.SaveChangesAsync();
        }
    }
}


//Quimicos
public class QuimicoRepository : IRepository<Quimico>
    {
        private readonly ApplicationDbContext _context;

        public QuimicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quimico>> GetAllAsync()
        {
            return await _context.Quimicos.ToListAsync();
        }

        public async Task<Quimico> GetByIdAsync(int id)
        {
            return await _context.Quimicos.FindAsync(id);
        }

        public async Task AddAsync(Quimico quimico)
        {
            _context.Quimicos.Add(quimico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Quimico quimico)
        {
            _context.Quimicos.Update(quimico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var quimico = await _context.Quimicos.FindAsync(id);
            if (quimico != null)
            {
                _context.Quimicos.Remove(quimico);
                await _context.SaveChangesAsync();
            }
        }
    }


//Insitu
public class InsituRepository : IRepository<Insitu>
    {
        private readonly ApplicationDbContext _context;

        public InsituRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Insitu>> GetAllAsync()
        {
            return await _context.Insitus.ToListAsync();
        }

        public async Task<Insitu> GetByIdAsync(int id)
        {
            return await _context.Insitus.FindAsync(id);
        }

        public async Task AddAsync(Insitu insitu)
        {
            _context.Insitus.Add(insitu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Insitu insitu)
        {
            _context.Insitus.Update(insitu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var insitu = await _context.Insitus.FindAsync(id);
            if (insitu != null)
            {
                _context.Insitus.Remove(insitu);
                await _context.SaveChangesAsync();
            }
        }
    }


//Fisicos
public class FisicoRepository : IRepository<Fisico>
    {
        private readonly ApplicationDbContext _context;

        public FisicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fisico>> GetAllAsync()
        {
            return await _context.Fisicos.ToListAsync();
        }

        public async Task<Fisico> GetByIdAsync(int id)
        {
            return await _context.Fisicos.FindAsync(id);
        }

        public async Task AddAsync(Fisico fisico)
        {
            _context.Fisicos.Add(fisico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fisico fisico)
        {
            _context.Fisicos.Update(fisico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fisico = await _context.Fisicos.FindAsync(id);
            if (fisico != null)
            {
                _context.Fisicos.Remove(fisico);
                await _context.SaveChangesAsync();
            }
        }
    }

//Metales agua
public class MetalAguaRepository : IRepository<MetalAgua>
    {
        private readonly ApplicationDbContext _context;

        public MetalAguaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MetalAgua>> GetAllAsync()
        {
            return await _context.MetalAguas.ToListAsync();
        }

        public async Task<MetalAgua> GetByIdAsync(int id)
        {
            return await _context.MetalAguas.FindAsync(id);
        }

        public async Task AddAsync(MetalAgua metalAgua)
        {
            _context.MetalAguas.Add(metalAgua);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MetalAgua metalAgua)
        {
            _context.MetalAguas.Update(metalAgua);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var MetalAgua = await _context.MetalAguas.FindAsync(id);
            if (MetalAgua != null)
            {
                _context.MetalAguas.Remove(MetalAgua);
                await _context.SaveChangesAsync();
            }
        }
    }


//Biologicos
public class BiologicoRepository : IRepository<Biologico>
    {
        private readonly ApplicationDbContext _context;

        public BiologicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Biologico>> GetAllAsync()
        {
            return await _context.Biologicos.ToListAsync();
        }

        public async Task<Biologico> GetByIdAsync(int id)
        {
            return await _context.Biologicos.FindAsync(id);
        }

        public async Task AddAsync(Biologico biologico)
        {
            _context.Biologicos.Add(biologico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Biologico biologico)
        {
            _context.Biologicos.Update(biologico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var biologico = await _context.Biologicos.FindAsync(id);
            if (biologico != null)
            {
                _context.Biologicos.Remove(biologico);
                await _context.SaveChangesAsync();
            }
        }
    }


//Nutriente
public class NutrienteRepository : IRepository<Nutriente>
    {
        private readonly ApplicationDbContext _context;

        public NutrienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nutriente>> GetAllAsync()
        {
            return await _context.Nutrientes.ToListAsync();
        }

        public async Task<Nutriente> GetByIdAsync(int id)
        {
            return await _context.Nutrientes.FindAsync(id);
        }

        public async Task AddAsync(Nutriente nutriente)
        {
            _context.Nutrientes.Add(nutriente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Nutriente nutriente)
        {
            _context.Nutrientes.Update(nutriente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var nutriente = await _context.Nutrientes.FindAsync(id);
            if (nutriente != null)
            {
                _context.Nutrientes.Remove(nutriente);
                await _context.SaveChangesAsync();
            }
        }
    }


//Metal sedimental
public class MetalSedimentalRepository : IRepository<MetalSedimental>
    {
        private readonly ApplicationDbContext _context;

        public MetalSedimentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MetalSedimental>> GetAllAsync()
        {
            return await _context.MetalSedimentales.ToListAsync();
        }

        public async Task<MetalSedimental> GetByIdAsync(int id)
        {
            return await _context.MetalSedimentales.FindAsync(id);
        }

        public async Task AddAsync(MetalSedimental metalSedimental)
        {
            _context.MetalSedimentales.Add(metalSedimental);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MetalSedimental metalSedimental)
        {
            _context.MetalSedimentales.Update(metalSedimental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var metalSedimental = await _context.MetalSedimentales.FindAsync(id);
            if (metalSedimental != null)
            {
                _context.MetalSedimentales.Remove(metalSedimental);
                await _context.SaveChangesAsync();
            }
        }
    }

//Historial Excel
public class HistorialExcelRepository : IRepositoryHistorialExcel<HistorialExcel>
    {
        private readonly ApplicationDbContext _context;

        public HistorialExcelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistorialExcel>> GetAllAsync()
        {
            return await _context.HistorialExceles
             .Include(r => r.Campaña)  
                .ToListAsync();
        }

        public async Task<HistorialExcel> GetByIdAsync(int id)
        {
            return await _context.HistorialExceles
                .Include(r => r.Campaña)
                .FirstOrDefaultAsync(r => r.IdHistorialExcel == id);
        }

        public async Task<IEnumerable<HistorialExcel>> GetByCampañasAsync(int IdCampaña)
    {
        return await _context.HistorialExceles
            .Include(r => r.Campaña)
            .Where(c => c.IdCampaña == IdCampaña)
            .ToListAsync();
    }



        public async Task AddAsync(HistorialExcel historialExcel)
        {
            _context.HistorialExceles.Add(historialExcel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HistorialExcel historialExcel)
        {
            _context.HistorialExceles.Update(historialExcel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var historialExcel = await _context.HistorialExceles.FindAsync(id);
            if (historialExcel != null)
            {
                _context.HistorialExceles.Remove(historialExcel);
                await _context.SaveChangesAsync();
            }
        }
    }

//Documentos
public class DocumentoRepository : IRepository<Documento>
    {
        private readonly ApplicationDbContext _context;

        public DocumentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Documento>> GetAllAsync()
        {
            return await _context.Documentos.ToListAsync();
            
        }

        public async Task<Documento> GetByIdAsync(int id)
        {
            return await _context.Documentos.FindAsync(id);
        }

        public async Task AddAsync(Documento documento)
        {
            _context.Documentos.Add(documento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Documento documento)
        {
            _context.Documentos.Update(documento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Documento = await _context.Documentos.FindAsync(id);
            if (Documento != null)
            {
                _context.Documentos.Remove(Documento);
                await _context.SaveChangesAsync();
            }
        }
    }

//DocsCampaña
public class DocsCampañaRepository : IRepositoryDocsCampaña<DocsCampaña>
    {
        private readonly ApplicationDbContext _context;

        public DocsCampañaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocsCampaña>> GetAllAsync()
        {
            return await _context.DocsCampañas
             .Include(r => r.Campaña)  
             .Include(r => r.Documento)  
                .ToListAsync();
        }

        public async Task<DocsCampaña> GetByIdAsync(int id)
        {
            return await _context.DocsCampañas
                .Include(r => r.Campaña)
                .Include(r => r.Documento)
                .FirstOrDefaultAsync(r => r.Id_DocsCampaña == id);
        }

        public async Task<IEnumerable<DocsCampaña>> GetByCampañasAsync(int IdCampaña)
    {
        return await _context.DocsCampañas
            .Include(r => r.Campaña)
            .Include(r => r.Documento)
            .Where(c => c.IdCampaña == IdCampaña)
            .ToListAsync();
    }



        public async Task AddAsync(DocsCampaña docsCampaña)
        {
            _context.DocsCampañas.Add(docsCampaña);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DocsCampaña docsCampaña)
        {
            _context.DocsCampañas.Update(docsCampaña);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var DocsCampaña = await _context.DocsCampañas.FindAsync(id);
            if (DocsCampaña != null)
            {
                _context.DocsCampañas.Remove(DocsCampaña);
                await _context.SaveChangesAsync();
            }
        }
    }


}
