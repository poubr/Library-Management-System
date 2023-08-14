using AutoMapper;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Implementations
{
    public class BookService : BaseService<Book, BookReadDto, BookCreateDto, BookUpdateDto>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IMapper mapper): base(bookRepository, mapper)
        {
            _bookRepository = bookRepository;
        }
    }
}