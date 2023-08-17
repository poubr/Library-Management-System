using AutoMapper;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Domain.src.Shared;
using LibraryManagementSystem.Service.src.Abstractions;

namespace LibraryManagementSystem.Service.src.Implementations
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        private readonly IBaseRepository<T> _baseRepository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<T> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<TReadDto> GetOne(Guid id)
        {
            return _mapper.Map<TReadDto>( await _baseRepository.GetOne(id));
        }

        public async Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions)
        {
            return _mapper.Map<IEnumerable<TReadDto>>(await _baseRepository.GetAll(queryOptions));
        }

        public virtual async Task<TReadDto> CreateOne(TCreateDto newItem)
        {
            var newEntity = await _baseRepository.CreateOne(_mapper.Map<T>(newItem));
            return _mapper.Map<TReadDto>(newEntity);
        }

        public async Task<TReadDto> UpdateOne(Guid id, TUpdateDto updatedEntity)
        {
            var foundItem = await _baseRepository.GetOne(id);
            if (foundItem != null)
            {
                var updatedItem = await _baseRepository.UpdateOne(_mapper.Map<T>(updatedEntity));
                return _mapper.Map<TReadDto>(updatedItem);
                
            }
            else
            {
                throw new Exception();      // <<<------ add custom
            } 
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var foundItem = await _baseRepository.GetOne(id);
            if (foundItem != null)
            {
                await _baseRepository.DeleteOne(foundItem);
                return true;
            }  
            return false;
        }
    }
}