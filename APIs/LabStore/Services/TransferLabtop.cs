using LabStore.DTOs;
using LabStore.Models;

namespace LabStore.Services
{
    public static class TransferLabtop
    {
        public static LabtopDTO LabToLabDto(Labtop labtop)
        {
            return new LabtopDTO
            {
                Id = labtop.Id,
                Name = labtop.Name,
                Price = labtop.Price,
                Discount = labtop.Discount,
                Description = labtop.Description,
                Rate = labtop.Rate,
                BrandId = labtop.BrandId,
                Model = labtop.Model
            };
        }

        public static Labtop LabDtoToLab(LabtopDTO labtop)
        {
            return new Labtop
            {
                Name = labtop.Name,
                Price = labtop.Price,
                Discount = labtop.Discount ?? 0,
                Description = labtop.Description ?? string.Empty,
                Rate = labtop.Rate ?? 0,
                BrandId = labtop.BrandId,
                Model = labtop.Model
            };
        }

        public static List<LabtopDTO> LabsToLabsDto(IEnumerable<Labtop> labs)
        {
            return labs.Select(LabToLabDto).ToList();
        }
    }
}
