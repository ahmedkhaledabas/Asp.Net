using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult GetStudents()
        {
            SampleData sampleData = new SampleData();
            var result = sampleData.Students;
            return View("Index" , result);
        }

        public IActionResult ShowDesc(int id)
        {
            SampleData sampleData = new SampleData();
            var result = sampleData.Students.Find(e => e.Id == id);
            return View("Desc" , result);

        }
    }
}
