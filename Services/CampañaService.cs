using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
    /// <summary>
    /// Servicio que proporciona métodos para gestionar las operaciones relacionadas con 
    /// los objetos de tipo Campaña. Utiliza un repositorio genérico para realizar 
    /// operaciones CRUD asincrónicas como obtener, agregar, actualizar y eliminar 
    /// datos de Campaña.
    /// </summary>
   public class CampañaService
{
    private readonly IRepository<Campaña> _campañaRepository;

    public CampañaService(IRepository<Campaña> campañaRepository)
    {
        _campañaRepository = campañaRepository;
    }

    public async Task<IEnumerable<Campaña>> GetAllAsync()
    {
        return await _campañaRepository.GetAllAsync();
    }

    public async Task<Campaña> GetByIdAsync(int id)
    {
        return await _campañaRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Campaña campaña)
    {
        await _campañaRepository.AddAsync(campaña);
    }

    public async Task UpdateAsync(Campaña campaña)
    {
        await _campañaRepository.UpdateAsync(campaña);
    }

    public async Task DeleteAsync(int id)
    {
        await _campañaRepository.DeleteAsync(id);
    }
}
}