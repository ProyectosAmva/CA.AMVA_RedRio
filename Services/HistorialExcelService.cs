using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
   public class HistorialExcelService
{
    private readonly IRepositoryHistorialExcel<HistorialExcel> _historialExcelRepository;

    public HistorialExcelService(IRepositoryHistorialExcel<HistorialExcel> historialExcelRepository)
    {
        _historialExcelRepository = historialExcelRepository;
    }

    public async Task<IEnumerable<HistorialExcel>> GetAllAsync()
    {
        return await _historialExcelRepository.GetAllAsync();
    }

    public async Task<HistorialExcel> GetByIdAsync(int id)
    {
        return await _historialExcelRepository.GetByIdAsync(id);
    }
     public async Task<IEnumerable<HistorialExcel>> GetByCampañasAsync(int IdCampaña)
{
    return await _historialExcelRepository.GetByCampañasAsync(IdCampaña);
}

    public async Task AddAsync(HistorialExcel historialExcel)
    {
        await _historialExcelRepository.AddAsync(historialExcel);
    }

    public async Task UpdateAsync(HistorialExcel historialExcel)
    {
        await _historialExcelRepository.UpdateAsync(historialExcel);
    }

    public async Task DeleteAsync(int id)
    {
        await _historialExcelRepository.DeleteAsync(id);
    }
}
}