using System.Collections.Generic;
using System.Threading.Tasks;
using AMVA.REDRIO.Models;

namespace AMVA.REDRIO.Repositories
{
    /// <summary>
    /// Interfaz genérica para realizar operaciones CRUD en una entidad de tipo T.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }

 /// <summary>
    /// Interfaz especializada para la entidad Estacion, que permite recuperar una estación por su código.
    /// </summary>
    public interface IRepositoryEstacion<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
         Task<T> GetByCodigoAsync(string codigo);
    }

/// <summary>
    /// Interfaz especializada para gestionar reportes de laboratorios.
    /// </summary>
    public interface IRepositoryReporteLaboratorio<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetByCampañaAsync(int idCampaña);
    }

/// <summary>
    /// Interfaz especializada para gestionar historial de excel.
    /// </summary>
    public interface IRepositoryHistorialExcel<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetByCampañasAsync(int idCampaña);
    }

/// <summary>
    /// Interfaz especializada para gestionar los documentos asociados a campañas.
    /// </summary>
    public interface IRepositoryDocsCampaña<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetByCampañasAsync(int idCampaña);
    }
}
