using LibraryManagementSystem.Domain.src.Shared;

namespace LibraryManagementSystem.Domain.src.RepositoryInterfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateOne(T newEntity);
        Task<T?> GetOne(Guid id);
        Task<IEnumerable<T>> GetAll(QueryOptions queryOptions);
        Task<T> UpdateOne(T updatedEntity);
        Task<bool> DeleteOne(T foundEntity);
    }
}