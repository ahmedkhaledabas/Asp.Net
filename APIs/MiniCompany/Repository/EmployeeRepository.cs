using Microsoft.AspNetCore.Http.HttpResults;
using MiniCompany.Data;
using MiniCompany.IRepository;
using MiniCompany.Model;

namespace MiniCompany.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        MiniCompanyDbContext context;
        public EmployeeRepository(MiniCompanyDbContext context) { 
            this.context = context;
        }
        void IEmployeeRepository.Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        void IEmployeeRepository.Delete(int id) {
            var emp = context.Employees.Find(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }

        List<Employee> IEmployeeRepository.GetAll() => context.Employees.ToList();

        Employee IEmployeeRepository.GetById(int id) => context.Employees.Find(id);

        void IEmployeeRepository.Update(Employee employee)
        {
            var findEmployee = context.Employees.Find(employee.Id);
            if (findEmployee != null)
            {
                findEmployee.Salary = employee.Salary;
                findEmployee.Name = employee.Name ;
                findEmployee.Email = employee.Email ;
                findEmployee.DepartmentId = employee.DepartmentId ;

                context.SaveChanges();
            }
            
        }


    }
}
