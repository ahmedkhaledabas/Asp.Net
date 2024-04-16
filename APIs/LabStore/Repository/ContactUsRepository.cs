using LabStore.Data;
using LabStore.IRepository;
using LabStore.Models;

namespace LabStore.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly LabStoreDbContext labStoreDbContext;

        public ContactUsRepository(LabStoreDbContext labStoreDbContext)
        {
            this.labStoreDbContext = labStoreDbContext;
        }
        public void Create(ContactUs contact)
        {
            labStoreDbContext.ContactUs.Add(contact);
            labStoreDbContext.SaveChanges();
        }

        public void Delete(ContactUs contact)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetAll() => labStoreDbContext.ContactUs.ToList();

        public ContactUs GetById(int id) => labStoreDbContext.ContactUs.Find(id);

        public void Update(ContactUs contact)
        {
            throw new NotImplementedException();
        }
    }
}
