using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
   public class TipoFaseService
{
    private readonly IRepository<TipoFase> _tipoFaseRepository;

    public TipoFaseService(IRepository<TipoFase> tipoFaseRepository)
    {
        _tipoFaseRepository = tipoFaseRepository;
    }

    public async Task<IEnumerable<TipoFase>> GetAllAsync()
    {
        return await _tipoFaseRepository.GetAllAsync();
    }

    public async Task<TipoFase> GetByIdAsync(int id)
    {
        return await _tipoFaseRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(TipoFase tipoFase)
    {
        await _tipoFaseRepository.AddAsync(tipoFase);
    }

    public async Task UpdateAsync(TipoFase tipoFase)
    {
        await _tipoFaseRepository.UpdateAsync(tipoFase);
    }

    public async Task DeleteAsync(int id)
    {
        await _tipoFaseRepository.DeleteAsync(id);
    }
}

}
