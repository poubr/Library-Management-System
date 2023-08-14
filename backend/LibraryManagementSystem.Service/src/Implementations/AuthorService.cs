using AutoMapper;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Implementations
{
    public class AuthorService : BaseService<Author, AuthorReadDto, AuthorCreateDto, AuthorUpdateDto>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper) : base(authorRepository, mapper)
        {
            _authorRepository = authorRepository;
        }
    }
}