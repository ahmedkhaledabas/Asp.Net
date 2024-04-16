using LabStore.DTOs;
using LabStore.Models;
using Microsoft.AspNetCore.Identity;

namespace LabStore.Services
{
    public static class TransferUser
    {
        public static ApplicationUser UserDtoToUser(ApplicationUserDTO applicationUserDTO)
        {
            return new ApplicationUser
            {
                FirstName = applicationUserDTO.FirstName,
                LastName = applicationUserDTO.LastName,
                Email = applicationUserDTO.Email,
                PasswordHash = applicationUserDTO.PasswordHash,
                UserName = applicationUserDTO.UserName
            };
        }

        public static ApplicationUserDTO UserToUserDto(ApplicationUser applicationUser)
        {
            return new ApplicationUserDTO
            {
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.Email,
                PasswordHash = applicationUser.PasswordHash,
                UserName = applicationUser.UserName
            };
        }

        public static List<ApplicationUserDTO> UsersToUserDtos(List<ApplicationUser> applicationUsers)
        {
            List<ApplicationUserDTO> applicationUserDTOs = new List<ApplicationUserDTO>();
            foreach (var item in applicationUsers)
            {
                var userDto = new ApplicationUserDTO()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PasswordHash = item.PasswordHash,
                    UserName = item.UserName
                };
                applicationUserDTOs.Add(userDto);
            }
            return applicationUserDTOs;  
            
        }
    }
}
