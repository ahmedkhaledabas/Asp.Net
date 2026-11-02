using LabStore.DTOs;
using LabStore.Models;

namespace LabStore.Services
{
    public static class TransferUser
    {
        public static ApplicationUser UserDtoToUser(ApplicationUserDTO dto)
        {
            return new ApplicationUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.UserName
            };
        }

        public static UserResponseDTO UserToUserDto(ApplicationUser user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };
        }

        public static List<UserResponseDTO> UsersToUserDtos(IEnumerable<ApplicationUser> users)
        {
            return users.Select(UserToUserDto).ToList();
        }
    }
}
