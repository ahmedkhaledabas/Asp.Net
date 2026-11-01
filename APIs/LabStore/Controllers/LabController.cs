using LabStore.DTOs;
using LabStore.IRepository;
using LabStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly ILabtopRepository labtopRepository;

        public LabController(ILabtopRepository labtopRepository)
        {
            this.labtopRepository = labtopRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var labs = labtopRepository.GetLabs();
            return Ok(TransferLabtop.LabsToLabsDto(labs));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var lab = labtopRepository.GetLab(id);
            return lab is null ? NotFound() : Ok(TransferLabtop.LabToLabDto(lab));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] LabtopDTO labtop)
        {
            var lab = TransferLabtop.LabDtoToLab(labtop);
            labtopRepository.CreateLab(lab);
            return CreatedAtAction(nameof(GetById), new { id = lab.Id }, TransferLabtop.LabToLabDto(lab));
        }

        [HttpGet("search/{searchItem}")]
        public IActionResult Search(string searchItem)
        {
            var labs = labtopRepository.SearchByLab(searchItem);
            if (labs.Count == 0)
            {
                labs = labtopRepository.SearchByBrand(searchItem);
            }

            return labs.Count == 0
                ? NotFound()
                : Ok(TransferLabtop.LabsToLabsDto(labs));
        }

        [HttpGet("filterBrand")]
        public IActionResult GetByBrand([FromQuery] int id)
        {
            var labs = labtopRepository.GetByBrand(id);
            return labs.Count == 0 ? NotFound() : Ok(TransferLabtop.LabsToLabsDto(labs));
        }

        [HttpGet("filterPrice")]
        public IActionResult GetByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            if (min < 0 || max < min)
            {
                return BadRequest(new { message = "Price range is invalid." });
            }

            var labs = labtopRepository.GetByPrice(min, max);
            return labs.Count == 0 ? NotFound() : Ok(TransferLabtop.LabsToLabsDto(labs));
        }

        [HttpGet("filterRate")]
        public IActionResult GetByRate([FromQuery] int rate)
        {
            if (rate is < 0 or > 5)
            {
                return BadRequest(new { message = "Rate must be between 0 and 5." });
            }

            var labs = labtopRepository.GetByRate(rate);
            return labs.Count == 0 ? NotFound() : Ok(TransferLabtop.LabsToLabsDto(labs));
        }
    }
}
