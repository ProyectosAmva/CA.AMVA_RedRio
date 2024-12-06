using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Services
{
     /// <summary>
    /// Servicio que gestiona las operaciones relacionadas con los objetos de tipo Quimico.
    /// para realizar operaciones CRUD asincrónicas, 
    /// como obtener, agregar, actualizar y eliminar los datos de Quimico.
    /// </summary>
    public class QuimicoService
    {
        private readonly IRepository<Quimico> _quimicoRepository;

        public QuimicoService(IRepository<Quimico> quimicoRepository)
        {
            _quimicoRepository = quimicoRepository;
        }

        public async Task<IEnumerable<Quimico>> GetAllAsync()
        {
            return await _quimicoRepository.GetAllAsync();
        }

        public async Task<Quimico> GetByIdAsync(int id)
        {
            return await _quimicoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Quimico quimico)
        {
            await _quimicoRepository.AddAsync(quimico);
        }

        public async Task UpdateAsync(Quimico quimico)
        {
            await _quimicoRepository.UpdateAsync(quimico);
        }

        public async Task DeleteAsync(int id)
        {
            await _quimicoRepository.DeleteAsync(id);
        }
    }
}
