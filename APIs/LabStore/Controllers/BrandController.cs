using LabStore.DTOs;
using LabStore.IRepository;
using LabStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = brandRepository.GetBrands();
            return Ok(TransferBrand.BrandsToBrandsDto(brands));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] BrandDTO brandDto)
        {
            var brand = TransferBrand.BrandDtoToBrand(brandDto);
            brandRepository.CreateBrand(brand);
            return CreatedAtAction(nameof(GetAll), TransferBrand.BrandToBrandDto(brand));
        }
    }
}
