using LabStore.Models;
using LabStore.DTOs;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace LabStore.Services
{
    public static class TransferLabtop
    {
        public static LabtopDTO LabToLabDto(Labtop labtop)
        {
        LabtopDTO newLab = new LabtopDTO()
        {
            Id = labtop.Id,
            Name = labtop.Name,
            Price = labtop.Price,
            Discount = (decimal)labtop.Discount,
            Description = labtop.Description,
            Rate = (int)labtop.Rate,
            BrandId = labtop.BrandId
        };
            return newLab;
        }

        public static Labtop LabDtoToLab(LabtopDTO labtop)
        {
            Labtop newLab = new Labtop()
            {
                Id = labtop.Id,
                Name = labtop.Name,
                Price = labtop.Price,
                Discount = (decimal)labtop.Discount,
                Description = labtop.Description,
                Rate = (int)labtop.Rate,
                BrandId = labtop.BrandId
            };
            return newLab;
        }

        public static List<LabtopDTO> LabsToLabsDto(List<Labtop> labs)
        {
            List<LabtopDTO> labtopDTOs = new List<LabtopDTO>();
            foreach (var item in labs)
            {
                var labDto = LabToLabDto(item);
                labtopDTOs.Add(labDto);
            }
            return labtopDTOs;
        }
    }
}
