using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
    /// <summary>
    /// Servicio que proporciona métodos para gestionar las operaciones relacionadas con 
    /// los objetos de tipo Fase. Utiliza un repositorio genérico para realizar 
    /// operaciones CRUD asincrónicas como obtener, agregar, actualizar y eliminar 
    /// datos de Fase.
    /// </summary>
    public class FaseService
    {
        private readonly IRepository<Fase> _faseRepository;

        public FaseService(IRepository<Fase> faseRepository)
        {
            _faseRepository = faseRepository;
        }

        public async Task<IEnumerable<Fase>> GetAllAsync()
        {
            return await _faseRepository.GetAllAsync();
        }

        public async Task<Fase> GetByIdAsync(int id)
        {
            return await _faseRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Fase fase)
        {
            await _faseRepository.AddAsync(fase);
        }

        public async Task UpdateAsync(Fase fase)
        {
            await _faseRepository.UpdateAsync(fase);
        }

        public async Task DeleteAsync(int id)
        {
            await _faseRepository.DeleteAsync(id);
        }
    }
}
