using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AddressProject.Common.DTO;
using AddressProject.DAL.Model;
using AddressProject.DAL.Repository;

namespace AddressProject.Business.Services
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAsync();
        
        public Task<UserDTO> CreateAsync(UserDTO userDTO);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<List<UserDTO>> GetAsync()
        {
            var users = new List<UserDTO>();
            
            var results = await _userRepository.GetAsync();

            foreach (var result in results)
                users.Add(Map(result));

            return users;
        }

        public async Task<UserDTO> CreateAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Fullname = userDTO.FullName,
                AddressStreet = userDTO.Address.Street,
                AddressLatitude = userDTO.Address.Latitude,
                AddressLongitude = userDTO.Address.Longitude,
                CreationDate = DateTime.Now
            };

            var result = await _userRepository.CreateAsync(user);
            
            return Map(result);
        }

        private UserDTO Map(User user)
        {
            return new UserDTO
            {
                FullName = user.Fullname,
                Address = new AddressDTO
                {
                    Latitude = user.AddressLatitude,
                    Longitude = user.AddressLongitude,
                    Street = user.AddressStreet
                }
            };
        }
    }
}