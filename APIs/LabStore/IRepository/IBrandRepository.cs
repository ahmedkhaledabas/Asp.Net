using LabStore.Models;

namespace LabStore.IRepository
{
    public interface IBrandRepository
    {
        List<Brand> GetBrands();
        Brand GetBrand(int id);
        void DeleteBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void CreateBrand(Brand brand);
    }
}
