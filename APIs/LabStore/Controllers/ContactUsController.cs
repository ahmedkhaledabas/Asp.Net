using LabStore.DTOs;
using LabStore.IRepository;
using LabStore.Services;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Create([FromBody] ContactUsDTO usDTO)
        {
            var contactUs = TransferContactUs.ContactUsDtoToContact(usDTO);
            contactUsRepository.Create(contactUs);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var contacts = contactUsRepository.GetAll();
            return Ok(TransferContactUs.ContactUsToDtos(contacts));
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(int id)
        {
            var contactUs = contactUsRepository.GetById(id);
            return contactUs is null ? NotFound() : Ok(TransferContactUs.ContactUsToContactDto(contactUs));
        }
    }
}
