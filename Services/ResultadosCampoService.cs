using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
     /// <summary>
    /// Servicio para manejar las operaciones relacionadas con los resultados de campo.
    /// Proporciona métodos asincrónicos para obtener, agregar, actualizar y eliminar
    /// resultados de campo a través del repositorio correspondiente.
    /// </summary>
   public class ResultadoCampoService
{
    private readonly IRepository<ResultadoCampo> _resultadoCampoRepository;

    public ResultadoCampoService(IRepository<ResultadoCampo> resultadoCampoRepository)
    {
        _resultadoCampoRepository = resultadoCampoRepository;
    }

    public async Task<IEnumerable<ResultadoCampo>> GetAllAsync()
    {
        return await _resultadoCampoRepository.GetAllAsync();
    }

    public async Task<ResultadoCampo> GetByIdAsync(int id)
    {
        return await _resultadoCampoRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(ResultadoCampo resultadoCampo)
    {
        await _resultadoCampoRepository.AddAsync(resultadoCampo);
    }

    public async Task UpdateAsync(ResultadoCampo resultadoCampo)
    {
        await _resultadoCampoRepository.UpdateAsync(resultadoCampo);
    }

    public async Task DeleteAsync(int id)
    {
        await _resultadoCampoRepository.DeleteAsync(id);
    }
}
}