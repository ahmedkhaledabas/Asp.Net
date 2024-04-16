using LabStore.DTOs;
using LabStore.Models;

namespace LabStore.Services
{
    public static class TransferContactUs
    {
        public static ContactUs ContactUsDtoToContact (ContactUsDTO contactUsDto)
        {
            return new ContactUs
            {
                Email = contactUsDto.Email,
                Message = contactUsDto.Message,
                Name = contactUsDto.Name
            };
        }

        public static ContactUsDTO ContactUsToContactDto(ContactUs contactUs)
        {
            return new ContactUsDTO
            {
                Email = contactUs.Email,
                Message = contactUs.Message,
                Name = contactUs.Name
            };
        }

        public static List<ContactUsDTO> ContactUsToDtos (List<ContactUs> contacts)
        {
            List<ContactUsDTO> usDTOs = new List<ContactUsDTO> ();
            foreach (ContactUs contact in contacts)
            {
                var dto = new ContactUsDTO()
                {
                    Name = contact.Name,
                    Email = contact.Email,
                    Message = contact.Message
                };
                usDTOs.Add(dto);
            }
            return usDTOs;
        }
    }
}
