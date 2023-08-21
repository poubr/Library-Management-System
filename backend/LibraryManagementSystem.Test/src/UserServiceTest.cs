// I'm honestly not even sure if this is the correct way to do this,
// really only going by an example I got online and
// I cannot seem to get it work (altough crating user for real does work).
// Am I on the right track here with the repositories?

// using System.Threading.Tasks;
// using AutoMapper;
// using LibraryManagementSystem.Domain.src.Entities;
// using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
// using LibraryManagementSystem.Service.src.Dtos;
// using LibraryManagementSystem.Service.src.Implementations;
// using Moq;
// using Xunit;

// namespace LibraryManagementSystem.Service.Tests
// {
//     public class UserServiceTests
//     {
//         [Fact]
//         public async Task CreateOne_Should_Create_User_And_Return_Dto()
//         {
//             var newUserDto = new UserCreateDto
//             {
//                 FirstName = "Peikko",
//                 LastName = "Muumi",
//                 Password = "salasana123",
//                 Email = "peikko@muumi.com",
//                 Address = "Muuminlaakso"
//             };

//             var newUser = new User
//             {
//                 Id = Guid.NewGuid(),
//                 FirstName = newUserDto.FirstName,
//                 LastName = newUserDto.LastName,
//                 Password = newUserDto.Password,
//                 Email = newUserDto.Email,
//                 Address = newUserDto.Address,
//                 CreatedAt = DateTime.Now,
//                 UpdatedAt = DateTime.Now,
//             };

//             var mockUserRepository = new Mock<IUserRepository>();
//             mockUserRepository.Setup(repository => repository.CreateOne(It.IsAny<User>()))
//                 .ReturnsAsync(newUser);

//             var mockMapper = new Mock<IMapper>();
//             mockMapper.Setup(mapper => mapper.Map<User>(newUserDto))
//                 .Returns(newUser);

//             var userService = new UserService(mockUserRepository.Object, mockMapper.Object);

//             var createdUserDto = await userService.CreateOne(newUserDto);

//             Assert.Equal(newUserDto.FirstName, createdUserDto.FirstName);
//         }
//     }
// }
