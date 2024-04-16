using LabStore.DTOs;
using LabStore.IRepository;
using LabStore.Services;
using Microsoft.AspNetCore.Http;
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
            var brandsDto = TransferBrand.BrandsToBrandsDto(brands);
            return Ok(brandsDto);
        }

        [HttpPost]
        public IActionResult Create(BrandDTO brandDto)
        {
            var brand = TransferBrand.BrandDtoToBrand(brandDto);
            brandRepository.CreateBrand(brand);
            return Ok(brandDto);
        }
    }
}
