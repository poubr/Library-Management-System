using LibraryManagementSystem.Domain.src.Shared;

namespace LibraryManagementSystem.Service.src.Abstractions
{
    public interface IBaseService <T, TReadDto, TCreateDto, TUpdateDto>
    {
        Task<TReadDto> CreateOne(TCreateDto dto);
        Task<TReadDto> GetOne(Guid id);
        Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions);
        Task<TReadDto> UpdateOne(Guid id, TUpdateDto updatedEntity);
        Task<bool> DeleteOne(Guid id);
    }
}