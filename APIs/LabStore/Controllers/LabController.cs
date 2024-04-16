using LabStore.DTOs;
using LabStore.IRepository;
using LabStore.Services;
using Microsoft.AspNetCore.Http;
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
            var labsDto = TransferLabtop.LabsToLabsDto(labs);
            return Ok(labsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var lab = labtopRepository.GetLab(id);
            if(lab != null)
            {
                var labDTO = TransferLabtop.LabToLabDto(lab);
            return Ok(labDTO);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(LabtopDTO labtop)
        {
            var lab = TransferLabtop.LabDtoToLab(labtop);
            labtopRepository.CreateLab(lab);
            return Ok(labtop);
        }

        [HttpGet]
        [Route("search/{searchItem}")]
        public IActionResult Search(string searchItem)
        {
            var labs = labtopRepository.SearchByLab(searchItem);
            var labs2 = labtopRepository.SearchByBrand(searchItem);
            if (labs.Count > 0)
            {
                var labsDTO = TransferLabtop.LabsToLabsDto(labs);
                return Ok(labsDTO);
            }else if(labs2.Count > 0)
            {
                var labsDTO = TransferLabtop.LabsToLabsDto(labs2);
                return Ok(labsDTO);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("filterBrand/")]
        public IActionResult GetByBrand(int id)
        {
            var labs = labtopRepository.GetByBrand(id);
            if(labs.Count > 0)
            {
                var labDTO = TransferLabtop.LabsToLabsDto(labs);
                return Ok(labDTO);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("filterPrice/")]
        public IActionResult GetByPrice(decimal min , decimal max)
        {
            var labs = labtopRepository.GetByPrice(min, max);
            if (labs.Count > 0)
            {
                var labDTO = TransferLabtop.LabsToLabsDto(labs);
                return Ok(labDTO);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("filterRate/")]
        public IActionResult GetByRate(int rate)
        {
            var labs = labtopRepository.GetByRate(rate);
            if (labs.Count > 0)
            {
                var labDTO = TransferLabtop.LabsToLabsDto(labs);
                return Ok(labDTO);
            }
            return NotFound();
        }


    }
}
