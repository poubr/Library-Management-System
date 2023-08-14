using AutoMapper;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Implementations
{
    public class GenreService : BaseService<Genre, GenreReadDto, GenreCreateDto, GenreUpdateDto>, IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository, IMapper mapper): base(genreRepository, mapper)
        {
            _genreRepository = genreRepository;
        }
    }
}