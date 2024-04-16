using LabStore.Models;

namespace LabStore.IRepository
{
    public interface IContactUsRepository
    {
        List<ContactUs> GetAll();
        ContactUs GetById(int id);
        void Delete(ContactUs contact);
        void Update(ContactUs contact);
        void Create(ContactUs contact);
    }
}
