using LabStore.DTOs;
using LabStore.Models;

namespace LabStore.Services
{
    public static class TransferBrand
    {
        public static Brand BrandDtoToBrand(BrandDTO dto)
        {
            return new Brand
            {
                Name = dto.Name
            };
        }

        public static BrandDTO BrandToBrandDto(Brand brand)
        {
            return new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }

        public static List<BrandDTO> BrandsToBrandsDto(IEnumerable<Brand> brands)
        {
            return brands.Select(BrandToBrandDto).ToList();
        }
    }
}
