using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using LibraryManagementSystem.Domain.src.Entities;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using LibraryManagementSystem.Service.src.Shared;

namespace LibraryManagementSystem.Service.src.Implementations
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }

        public override async Task<UserReadDto> CreateOne(UserCreateDto newItemDto)
        {
            var newEntity = _mapper.Map<User>(newItemDto);
            string passwordHash = BCryptNet.HashPassword(newEntity.Password);
            newEntity.Password = passwordHash;
            var createdUser = await _userRepository.CreateOne(newEntity);
            return _mapper.Map<UserReadDto>(createdUser);
        }

        public async Task<bool> CreateAdmin(Guid id)
        {
            var foundUser = await _userRepository.GetOne(id);
            if (foundUser != null)
            {
                _mapper.Map<UserReadDto>(await _userRepository.CreateAdmin(foundUser));
                return true;
            }
            else
            {
                throw ExceptionHandler.CreateAdminException();
            }  
        }

        public async Task<UserReadDto> UpdatePassword(Guid id, string newPassword)
        {
            var foundUser = await _userRepository.GetOne(id);
            if (foundUser != null)
            {
                string newHashPassword = BCryptNet.HashPassword(newPassword);
                foundUser.Password = newHashPassword;
                return _mapper.Map<UserReadDto>(await _userRepository.UpdatePassword(foundUser));
            }
            else
            {
                throw ExceptionHandler.UpdatePasswordException();
            }
        }
    }
}