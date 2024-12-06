using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
    public class MunicipioService
    {
        /// <summary>
    /// Servicio que proporciona métodos para gestionar las operaciones relacionadas con 
    /// los objetos de tipo Municipio. Utiliza un repositorio genérico para realizar 
    /// operaciones CRUD asincrónicas como obtener, agregar, actualizar y eliminar 
    /// datos de Municipio.
    /// </summary>
        private readonly IRepository<Municipio> _municipioRepository;

        public MunicipioService(IRepository<Municipio> municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }

        public async Task<IEnumerable<Municipio>> GetAllAsync()
        {
            return await _municipioRepository.GetAllAsync();
        }

        public async Task<Municipio> GetByIdAsync(int id)
        {
            return await _municipioRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Municipio municipio)
        {
            await _municipioRepository.AddAsync(municipio);
        }

        public async Task UpdateAsync(Municipio municipio)
        {
            await _municipioRepository.UpdateAsync(municipio);
        }

        public async Task DeleteAsync(int id)
        {
            await _municipioRepository.DeleteAsync(id);
        }
    }
}
