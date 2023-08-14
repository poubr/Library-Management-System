using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Service.src.Dtos;

namespace LibraryManagementSystem.Service.src.Abstractions
{
    public interface IGenreService : IBaseService<Genre, GenreReadDto, GenreCreateDto,GenreUpdateDto>
    {
        
    }
}