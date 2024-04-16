using LabStore.DTOs;
using LabStore.IRepository;
using LabStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository contactUsRepository;

        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            this.contactUsRepository = contactUsRepository;
        }

        [HttpPost]
        public IActionResult Create(ContactUsDTO usDTO)
        {
            if (ModelState.IsValid)
            {
                var contactUs = TransferContactUs.ContactUsDtoToContact(usDTO);
                contactUsRepository.Create(contactUs);
                return Ok(usDTO);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = contactUsRepository.GetAll();
            var contactsDto = TransferContactUs.ContactUsToDtos(contacts);
            return Ok(contactsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var contactUs = contactUsRepository.GetById(id);
            if(contactUs != null)
            {
                var contactDto = TransferContactUs.ContactUsToContactDto(contactUs);
                return Ok(contactDto);
            }
            return NotFound();
        }
    }
}
