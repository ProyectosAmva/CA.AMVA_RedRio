using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
     /// <summary>
    /// Servicio para manejar las operaciones relacionadas con los tipos de fuente.
    /// Proporciona métodos asincrónicos para obtener, agregar, actualizar y eliminar
    /// tipos de fuente a través del repositorio correspondiente.
    /// </summary>
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
