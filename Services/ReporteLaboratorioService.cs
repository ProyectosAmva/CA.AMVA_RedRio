using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
      /// <summary>
    /// Servicio para gestionar los reportes de laboratorio. 
    /// Realiza operaciones como obtener, agregar, actualizar y eliminar reportes relacionados con las campañas.
    /// </summary>
    public class ReportesLaboratorioService
    {   
        private readonly IRepositoryReporteLaboratorio<ReportesLaboratorio> _reportesLaboratorioRepository;

        public ReportesLaboratorioService(IRepositoryReporteLaboratorio<ReportesLaboratorio> reportesLaboratorioRepository)
        {
            _reportesLaboratorioRepository = reportesLaboratorioRepository;
        }

        public async Task<IEnumerable<ReportesLaboratorio>> GetAllAsync()
        {
            return await _reportesLaboratorioRepository.GetAllAsync();
        }

        public async Task<ReportesLaboratorio> GetByIdAsync(int id)
        {
            return await _reportesLaboratorioRepository.GetByIdAsync(id);
        }

       public async Task<IEnumerable<ReportesLaboratorio>> GetByCampañaAsync(int IdCampaña)
        {
            return await _reportesLaboratorioRepository.GetByCampañaAsync(IdCampaña);
        }

        public async Task AddAsync(ReportesLaboratorio reportesLaboratorio)
        {
            await _reportesLaboratorioRepository.AddAsync(reportesLaboratorio);
        }

        public async Task UpdateAsync(ReportesLaboratorio reportesLaboratorio)
        {
            await _reportesLaboratorioRepository.UpdateAsync(reportesLaboratorio);
        }

        public async Task DeleteAsync(int id)
        {
            await _reportesLaboratorioRepository.DeleteAsync(id);
        }
    }
}
