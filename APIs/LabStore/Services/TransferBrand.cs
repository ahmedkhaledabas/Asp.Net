using LabStore.DTOs;
using LabStore.Models;

namespace LabStore.Services
{
    public static class TransferBrand
    {
        public static Brand BrandDtoToBrand(BrandDTO brand)
        {
            var newBrand = new Brand()
            {
                Id = brand.Id,
                Name = brand.Name
            };
            return newBrand;
        }

        public static BrandDTO BrandToBrandDto(Brand brand)
        {
            var newBrand = new BrandDTO()
            {
                Id = brand.Id,
                Name = brand.Name
            };
            return newBrand;
        }

        public static List<BrandDTO> BrandsToBrandsDto(List<Brand> brands)
        {
            List<BrandDTO> brandDTOs = new List<BrandDTO>();
            foreach (var item in brands)
            {
                var newDto = BrandToBrandDto(item);
                brandDTOs.Add(newDto);
            }
            return brandDTOs;
        }
    }
}
