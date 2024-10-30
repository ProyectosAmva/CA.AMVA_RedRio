using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
    public class MuestraCompuestaService
    {
        private readonly IRepository<MuestraCompuesta> _MuestraCompuestaRepository;

        public MuestraCompuestaService(IRepository<MuestraCompuesta> MuestraCompuestaRepository)
        {
            _MuestraCompuestaRepository = MuestraCompuestaRepository;
        }

        public async Task<IEnumerable<MuestraCompuesta>> GetAllAsync()
        {
            return await _MuestraCompuestaRepository.GetAllAsync();
        }

        public async Task<MuestraCompuesta> GetByIdAsync(int id)
        {
            return await _MuestraCompuestaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(MuestraCompuesta muestraCompuesta)
        {
            await _MuestraCompuestaRepository.AddAsync(muestraCompuesta);
        }

        public async Task UpdateAsync(MuestraCompuesta muestraCompuesta)
        {
            await _MuestraCompuestaRepository.UpdateAsync(muestraCompuesta);
        }

        public async Task DeleteAsync(int id)
        {
            await _MuestraCompuestaRepository.DeleteAsync(id);
        }
    }
}
