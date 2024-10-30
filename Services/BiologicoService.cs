using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
   public class BiologicoService
{
    private readonly IRepository<Biologico> _biologicoRepository;

    public BiologicoService(IRepository<Biologico> biologicoRepository)
    {
        _biologicoRepository = biologicoRepository;
    }

    public async Task<IEnumerable<Biologico>> GetAllAsync()
    {
        return await _biologicoRepository.GetAllAsync();
    }

    public async Task<Biologico> GetByIdAsync(int id)
    {
        return await _biologicoRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Biologico biologico)
    {
        await _biologicoRepository.AddAsync(biologico);
    }

    public async Task UpdateAsync(Biologico biologico)
    {
        await _biologicoRepository.UpdateAsync(biologico);
    }

    public async Task DeleteAsync(int id)
    {
        await _biologicoRepository.DeleteAsync(id);
    }
}
}