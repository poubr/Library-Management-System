using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using JWT.Algorithms;
using JWT.Builder;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Dtos;
using LibraryManagementSystem.Service.src.Shared;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Service.src.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> VerifyCredentials(UserAuthDto userAuthDto)
        {
            var foundUser = await _userRepository.VerifyCredentials(userAuthDto.Email, userAuthDto.Password);
            if (foundUser != null)
            {
                var jwtSecretKey = _configuration["JwtSecretKey"];
                var token = JwtBuilder.Create()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(jwtSecretKey)
                    .AddClaim(ClaimTypes.Email, foundUser.Email)
                    .AddClaim(ClaimTypes.NameIdentifier, foundUser.Id)
                    .AddClaim(ClaimTypes.Role, foundUser.Role.ToString())
                    .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(60).ToUnixTimeSeconds())
                    .MustVerifySignature()
                    .Encode();
                return token;
            }
            else
            {
                throw ExceptionHandler.UnauthorizedException();
            }
        }
    }
}