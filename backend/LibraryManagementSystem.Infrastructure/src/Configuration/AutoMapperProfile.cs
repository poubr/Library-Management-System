using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Infrastructure.src.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<AuthorCreateDto, Author>();

            CreateMap<Book, BookReadDto>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<BookCreateDto, Book>();

            CreateMap<Genre, GenreReadDto>();
            CreateMap<GenreUpdateDto, Genre>();
            CreateMap<GenreCreateDto, Genre>();

            CreateMap<Loan, LoanReadDto>();
            CreateMap<LoanUpdateDto, Loan>();
            CreateMap<LoanCreateDto, Loan>();

            CreateMap<User, UserReadDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();
        }
    }
}