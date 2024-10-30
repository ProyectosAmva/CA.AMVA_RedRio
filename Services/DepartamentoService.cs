using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMVA.REDRIO.Services
{
    public class DepartamentoService
    {
        private readonly IRepository<Departamento> _departamentoRepository;

        public DepartamentoService(IRepository<Departamento> departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _departamentoRepository.GetAllAsync();
        }

        public async Task<Departamento> GetByIdAsync(int id)
        {
            return await _departamentoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Departamento departamento)
        {
            await _departamentoRepository.AddAsync(departamento);
        }

        public async Task UpdateAsync(Departamento departamento)
        {
            await _departamentoRepository.UpdateAsync(departamento);
        }

        public async Task DeleteAsync(int id)
        {
            await _departamentoRepository.DeleteAsync(id);
        }
    }
}
