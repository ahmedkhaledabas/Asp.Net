using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCompany.IRepository;
using MiniCompany.Model;
using MiniCompany.ViewModel;

namespace MiniCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department()
                {
                    Name = departmentViewModel.Name
                };
                departmentRepository.Create(department);
                return Ok(department);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(departmentRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = departmentRepository.GetById(id);
            if(emp != null)
            {
                return Ok(emp);
            }
            return BadRequest();
        }
    }
}
