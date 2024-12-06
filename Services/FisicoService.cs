using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Services
{
     /// <summary>
    /// Servicio que proporciona métodos para gestionar las operaciones relacionadas con 
    /// los objetos de tipo Fisico. Utiliza un repositorio genérico para realizar 
    /// operaciones CRUD asincrónicas como obtener, agregar, actualizar y eliminar 
    /// datos de Fisico.
    /// </summary>
    public class FisicoService
    {
        private readonly IRepository<Fisico> _fisicoRepository;

        public FisicoService(IRepository<Fisico> fisicoRepository)
        {
            _fisicoRepository = fisicoRepository;
        }

        public async Task<IEnumerable<Fisico>> GetAllAsync()
        {
            return await _fisicoRepository.GetAllAsync();
        }

        public async Task<Fisico> GetByIdAsync(int id)
        {
            return await _fisicoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Fisico Fisico)
        {
            await _fisicoRepository.AddAsync(Fisico);
        }

        public async Task UpdateAsync(Fisico Fisico)
        {
            await _fisicoRepository.UpdateAsync(Fisico);
        }

        public async Task DeleteAsync(int id)
        {
            await _fisicoRepository.DeleteAsync(id);
        }
    }
}
