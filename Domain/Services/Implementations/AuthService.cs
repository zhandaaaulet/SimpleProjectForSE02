
using DataTransfer.DTO;
using Domain.Model;
using Domain.Repositories;
using Domain.Security;
using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public User Register(RegisterUserDTO dto)
        {
            User user = new User
            {
                Login = dto.Login,
                PasswordHash = _passwordHasher.Hash(dto.Password),
                Role = Role.Customer,
                RegistrationDate = DateTime.UtcNow, 
            };
            _userRepository.CreateUser(user);
            return user;

        }
    }
}
