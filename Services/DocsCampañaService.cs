using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;
using AMVA.REDRIO.Repositories;

namespace AMVA.REDRIO.Services
{
   public class DocsCampañaService
{
    private readonly IRepositoryDocsCampaña<DocsCampaña> _docsCampañaRepository;

    public DocsCampañaService(IRepositoryDocsCampaña<DocsCampaña> docsCampañaRepository)
    {
        _docsCampañaRepository = docsCampañaRepository;
    }

    public async Task<IEnumerable<DocsCampaña>> GetAllAsync()
    {
        return await _docsCampañaRepository.GetAllAsync();
    }

    public async Task<DocsCampaña> GetByIdAsync(int id)
    {
        return await _docsCampañaRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(DocsCampaña DocsCampaña)
    {
        await _docsCampañaRepository.AddAsync(DocsCampaña);
    }

    public async Task UpdateAsync(DocsCampaña DocsCampaña)
    {
        await _docsCampañaRepository.UpdateAsync(DocsCampaña);
    }

    public async Task DeleteAsync(int id)
    {
        await _docsCampañaRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<DocsCampaña>> GetByCampañasAsync(int IdCampaña)
{
    return await _docsCampañaRepository.GetByCampañasAsync(IdCampaña);
}
    
}
}