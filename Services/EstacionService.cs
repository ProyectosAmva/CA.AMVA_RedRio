using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
    public class EstacionService
    {
        private readonly IRepositoryEstacion<Estacion> _estacionRepository;

        public EstacionService(IRepositoryEstacion<Estacion> estacionRepository)
        {
            _estacionRepository = estacionRepository;
        }

        public async Task<IEnumerable<Estacion>> GetAllAsync()
        {
            return await _estacionRepository.GetAllAsync();
        }

        public async Task<Estacion> GetByIdAsync(int id)
        {
            return await _estacionRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Estacion estacion)
        {
            await _estacionRepository.AddAsync(estacion);
        }

        public async Task UpdateAsync(Estacion estacion)
        {
            await _estacionRepository.UpdateAsync(estacion);
        }

        public async Task DeleteAsync(int id)
        {
            await _estacionRepository.DeleteAsync(id);
        }

         public async Task<Estacion> GetByCodigoAsync(string codigo) // Nuevo método
        {
            return await _estacionRepository.GetByCodigoAsync(codigo);
        }
    }
}
