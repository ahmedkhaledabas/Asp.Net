using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCompany.IRepository;
using MiniCompany.Model;
using MiniCompany.ViewModel;

namespace MiniCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) { 
            this.employeeRepository = employeeRepository;
        }


        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                    Id = employeeViewModel.Id,
                    Name = employeeViewModel.Name,
                    Salary = employeeViewModel.Salary,
                    Phone = employeeViewModel.Phone,
                    Email = employeeViewModel.Email,
                    DepartmentId = employeeViewModel.DepartmentId,
                };
                employeeRepository.Create(employee);
                return Ok(employee);
                //return Created(employee);
            }
            return BadRequest();
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var emps = employeeRepository.GetAll();
            return Ok(emps);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = employeeRepository.GetById(id);
            if(emp == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(emp);
            }
        }

        [HttpPut]
        public IActionResult Update(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                    Id = employeeViewModel.Id,
                    Name = employeeViewModel.Name,
                    Salary = employeeViewModel.Salary,
                    DepartmentId = employeeViewModel.DepartmentId,
                    Phone = employeeViewModel.Phone,
                    Email = employeeViewModel.Email
                };
                employeeRepository.Update(employee);
                return Ok(employee);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employeeRepository.GetById(id);
            if(emp != null)
            {
                employeeRepository.Delete(id);
                return Ok(emp);
            }
            return BadRequest();
        }
    }
}
