using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Services
{
    public class NutrienteService
    {
        private readonly IRepository<Nutriente> _nutrienteRepository;

        public NutrienteService(IRepository<Nutriente> nutrienteRepository)
        {
            _nutrienteRepository = nutrienteRepository;
        }

        public async Task<IEnumerable<Nutriente>> GetAllAsync()
        {
            return await _nutrienteRepository.GetAllAsync();
        }

        public async Task<Nutriente> GetByIdAsync(int id)
        {
            return await _nutrienteRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Nutriente nutriente)
        {
            await _nutrienteRepository.AddAsync(nutriente);
        }

        public async Task UpdateAsync(Nutriente nutriente)
        {
            await _nutrienteRepository.UpdateAsync(nutriente);
        }

        public async Task DeleteAsync(int id)
        {
            await _nutrienteRepository.DeleteAsync(id);
        }
    }
}
