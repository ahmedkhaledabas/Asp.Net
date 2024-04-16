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

        public void DeleteLab(Labtop lab)
        {
            throw new NotImplementedException();
        }

        public Labtop GetLab(int id) => labStoreDbContext.Labs.Find(id);

        public List<Labtop> GetLabs() => labStoreDbContext.Labs.ToList();

        public List<Labtop> SearchByLab(string searchItem) => labStoreDbContext.Labs.Where(l=>l.Name.Contains(searchItem)).ToList();

        public List<Labtop> SearchByBrand(string searchItem)
        {
            var brand = labStoreDbContext.Brands.Where(b => b.Name.Contains(searchItem)).FirstOrDefault();
            var labs = labStoreDbContext.Labs.Where(l => l.BrandId == brand.Id).ToList();
            return labs;
        }
          
        public void UpdateLab(Labtop lab)
        {
            throw new NotImplementedException();
        }

        public List<Labtop> GetByBrand(int id) => labStoreDbContext.Labs.Where(l => l.BrandId == id).ToList();

        public List<Labtop> GetByPrice(decimal min, decimal max) => labStoreDbContext.Labs.Where(l=>l.Price >= min && l.Price <= max).ToList();

        public List<Labtop> GetByRate(int rate) => labStoreDbContext.Labs.Where(l => l.Rate == rate).ToList();
    }
}
