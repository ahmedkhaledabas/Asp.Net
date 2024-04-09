using MiniCompany.Model;

namespace MiniCompany.IRepository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();

        Department GetById(int id);

        void Delete(int id);

        void Create(Department department);

        void Update(Department department);
    }
}
