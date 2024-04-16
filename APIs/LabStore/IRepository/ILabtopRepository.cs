using LabStore.DTOs;
using LabStore.Models;

namespace LabStore.IRepository
{
    public interface ILabtopRepository
    {
        List<Labtop> GetLabs();
        Labtop GetLab(int id);
        List<Labtop> GetByBrand(int id);
        List<Labtop> GetByPrice(decimal min , decimal max);
        List<Labtop> GetByRate(int rate);
        void DeleteLab(Labtop lab);
        void UpdateLab(Labtop lab);
        void CreateLab(Labtop lab);
        List<Labtop> SearchByLab(string searchItem);
        List<Labtop> SearchByBrand(string searchItem);
    }
}
