using LabStore.Data;
using LabStore.IRepository;
using LabStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LabStore.Repository
{
    public class LabRepository : ILabtopRepository
    {
        private readonly LabStoreDbContext labStoreDbContext;

        public LabRepository(LabStoreDbContext labStoreDbContext)
        {
            this.labStoreDbContext = labStoreDbContext;
        }

        public void CreateLab(Labtop lab)
        {
            labStoreDbContext.Labs.Add(lab);
            labStoreDbContext.SaveChanges();
        }

        public void DeleteLab(Labtop lab) => throw new NotImplementedException();

        public Labtop GetLab(int id) => labStoreDbContext.Labs.Find(id);

        public List<Labtop> GetLabs() => labStoreDbContext.Labs.AsNoTracking().ToList();

        public List<Labtop> SearchByLab(string searchItem) =>
            labStoreDbContext.Labs.AsNoTracking()
                .Where(lab => lab.Name.Contains(searchItem))
                .ToList();

        public List<Labtop> SearchByBrand(string searchItem)
        {
            var brandIds = labStoreDbContext.Brands.AsNoTracking()
                .Where(brand => brand.Name.Contains(searchItem))
                .Select(brand => brand.Id);

            return labStoreDbContext.Labs.AsNoTracking()
                .Where(lab => brandIds.Contains(lab.BrandId))
                .ToList();
        }

        public void UpdateLab(Labtop lab) => throw new NotImplementedException();

        public List<Labtop> GetByBrand(int id) =>
            labStoreDbContext.Labs.AsNoTracking().Where(lab => lab.BrandId == id).ToList();

        public List<Labtop> GetByPrice(decimal min, decimal max) =>
            labStoreDbContext.Labs.AsNoTracking()
                .Where(lab => lab.Price >= min && lab.Price <= max)
                .ToList();

        public List<Labtop> GetByRate(int rate) =>
            labStoreDbContext.Labs.AsNoTracking().Where(lab => lab.Rate == rate).ToList();
    }
}
