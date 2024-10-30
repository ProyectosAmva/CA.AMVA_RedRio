using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Services
{
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
