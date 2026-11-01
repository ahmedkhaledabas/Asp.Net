using LabStore.DTOs;
using LabStore.Models;

namespace LabStore.Services
{
    public static class TransferContactUs
    {
        public static ContactUs ContactUsDtoToContact(ContactUsDTO contactUsDto)
        {
            return new ContactUs
            {
                Email = contactUsDto.Email,
                Message = contactUsDto.Message,
                Name = contactUsDto.Name,
                Subject = contactUsDto.Subject
            };
        }

        public static ContactUsDTO ContactUsToContactDto(ContactUs contactUs)
        {
            return new ContactUsDTO
            {
                Email = contactUs.Email,
                Message = contactUs.Message,
                Name = contactUs.Name,
                Subject = contactUs.Subject
            };
        }

        public static List<ContactUsDTO> ContactUsToDtos(IEnumerable<ContactUs> contacts)
        {
            return contacts.Select(contact => ContactUsToContactDto(contact)).ToList();
        }
    }
}
