using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.IRepository;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeRepo collegeRepo;

        public CollegeController(ICollegeRepo collegeRepo)
        {
            this.collegeRepo = collegeRepo;
        }
    }
}
