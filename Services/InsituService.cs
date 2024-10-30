using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Services
{
    public class InsituService
    {
        private readonly IRepository<Insitu> _insituRepository;

        public InsituService(IRepository<Insitu> insituRepository)
        {
            _insituRepository = insituRepository;
        }

        public async Task<IEnumerable<Insitu>> GetAllAsync()
        {
            return await _insituRepository.GetAllAsync();
        }

        public async Task<Insitu> GetByIdAsync(int id)
        {
            return await _insituRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Insitu insitu)
        {
            await _insituRepository.AddAsync(insitu);
        }

        public async Task UpdateAsync(Insitu insitu)
        {
            await _insituRepository.UpdateAsync(insitu);
        }

        public async Task DeleteAsync(int id)
        {
            await _insituRepository.DeleteAsync(id);
        }
    }
}
