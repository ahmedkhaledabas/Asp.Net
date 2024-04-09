using MiniCompany.Model;

namespace MiniCompany.IRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        Employee GetById(int id);

        void Delete(int id);

        void Create(Employee employee);

        void Update(Employee employee);
    }
}
