using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
   public class DocumentoService
{
    private readonly IRepository<Documento> _documentoRepository;

    public DocumentoService(IRepository<Documento> documentoRepository)
    {
        _documentoRepository = documentoRepository;
    }

    public async Task<IEnumerable<Documento>> GetAllAsync()
    {
        return await _documentoRepository.GetAllAsync();
    }

    public async Task<Documento> GetByIdAsync(int id)
    {
        return await _documentoRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Documento documento)
    {
        await _documentoRepository.AddAsync(documento);
    }

    public async Task UpdateAsync(Documento documento)
    {
        await _documentoRepository.UpdateAsync(documento);
    }

    public async Task DeleteAsync(int id)
    {
        await _documentoRepository.DeleteAsync(id);
    }
}
}