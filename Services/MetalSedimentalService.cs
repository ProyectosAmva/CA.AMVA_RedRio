using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
    public class MetalSedimentalService
    {
        private readonly IRepository<MetalSedimental> _metalSedimentalRepository;

        public MetalSedimentalService(IRepository<MetalSedimental> MetalSedimentalRepository)
        {
            _metalSedimentalRepository = MetalSedimentalRepository;
        }

        public async Task<IEnumerable<MetalSedimental>> GetAllAsync()
        {
            return await _metalSedimentalRepository.GetAllAsync();
        }

        public async Task<MetalSedimental> GetByIdAsync(int id)
        {
            return await _metalSedimentalRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(MetalSedimental metalSedimental)
        {
            await _metalSedimentalRepository.AddAsync(metalSedimental);
        }

        public async Task UpdateAsync(MetalSedimental metalSedimental)
        {
            await _metalSedimentalRepository.UpdateAsync(metalSedimental);
        }

        public async Task DeleteAsync(int id)
        {
            await _metalSedimentalRepository.DeleteAsync(id);
        }
    }
}
