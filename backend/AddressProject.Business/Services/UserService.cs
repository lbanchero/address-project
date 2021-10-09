using System.Threading.Tasks;
using AddressProject.Common.DTO;
using AddressProject.DAL.Model;

namespace AddressProject.Business.Services
{
    public interface IUserService
    {
        public Task<UserDTO> Create(UserDTO userDTO);
    }

    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var user = new User
            {
                Fullname = userDTO.FullName,
                AddressStreet = userDTO.Address.Street,
                AddressLatitude = userDTO.Address.Latitude,
                AddressLongitude = userDTO.Address.Longitude
            };
            
            
            
            return new UserDTO();
        }
    }
}