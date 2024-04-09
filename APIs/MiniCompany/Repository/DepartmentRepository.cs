using MiniCompany.Data;
using MiniCompany.IRepository;
using MiniCompany.Model;

namespace MiniCompany.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        MiniCompanyDbContext context;
        public DepartmentRepository(MiniCompanyDbContext context) { 
            this.context = context;
        }
        void IDepartmentRepository.Create(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }

        void IDepartmentRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<Department> IDepartmentRepository.GetAll() => context.Departments.ToList();

        Department IDepartmentRepository.GetById(int id)
        {
            var emp = context.Departments.Find(id);

                return emp;
        }

        void IDepartmentRepository.Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
