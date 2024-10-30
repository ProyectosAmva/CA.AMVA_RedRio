using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Services
{
    public class MetalAguaService
    {
        private readonly IRepository<MetalAgua> _metalAguaRepository;

        public MetalAguaService(IRepository<MetalAgua> metalAguaRepository)
        {
            _metalAguaRepository = metalAguaRepository;
        }

        public async Task<IEnumerable<MetalAgua>> GetAllAsync()
        {
            return await _metalAguaRepository.GetAllAsync();
        }

        public async Task<MetalAgua> GetByIdAsync(int id)
        {
            return await _metalAguaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(MetalAgua MetalAgua)
        {
            await _metalAguaRepository.AddAsync(MetalAgua);
        }

        public async Task UpdateAsync(MetalAgua MetalAgua)
        {
            await _metalAguaRepository.UpdateAsync(MetalAgua);
        }

        public async Task DeleteAsync(int id)
        {
            await _metalAguaRepository.DeleteAsync(id);
        }
    }
}
