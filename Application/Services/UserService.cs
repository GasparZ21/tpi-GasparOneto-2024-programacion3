using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                return await _userRepository.GetUserById(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el professor por id.", ex);
            }
        }
        public async Task AddUser(UserDto userDto)
        {
            var user = new User(userDto.Id, userDto.Name, "USER");

            await _userRepository.Add(user);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            await _userRepository.Delete(user.Id);
        }
        public async Task<User> UpdateAsync(int id, User updatedUser)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser), "The updated assignment cannot be null.");
            }

            if (id != updatedUser.Id)
            {
                throw new ArgumentException("ID mismatch between the request and the assignment object.");
            }

            return await _userRepository.Update(updatedUser);

        }
    }
}
