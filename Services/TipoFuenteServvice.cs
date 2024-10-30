using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
   public class TipoFuenteService
{
    private readonly IRepository<TipoFuente> _tipoFuenteRepository;

    public TipoFuenteService(IRepository<TipoFuente> tipoFuenteRepository)
    {
        _tipoFuenteRepository = tipoFuenteRepository;
    }

    public async Task<IEnumerable<TipoFuente>> GetAllAsync()
    {
        return await _tipoFuenteRepository.GetAllAsync();
    }

    public async Task<TipoFuente> GetByIdAsync(int id)
    {
        return await _tipoFuenteRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(TipoFuente tipoFuente)
    {
        await _tipoFuenteRepository.AddAsync(tipoFuente);
    }

    public async Task UpdateAsync(TipoFuente tipoFuente)
    {
        await _tipoFuenteRepository.UpdateAsync(tipoFuente);
    }

    public async Task DeleteAsync(int id)
    {
        await _tipoFuenteRepository.DeleteAsync(id);
    }
}

}
