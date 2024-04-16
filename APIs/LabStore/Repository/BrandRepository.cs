using LabStore.Data;
using LabStore.IRepository;
using LabStore.Models;

namespace LabStore.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly LabStoreDbContext context;

        public BrandRepository(LabStoreDbContext context)
        {
            this.context = context;
        }
        public void CreateBrand(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
        }

        public void DeleteBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Brand GetBrand(int id)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetBrands() => context.Brands.ToList();

        public void UpdateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
