using ContactDoctor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View(new SampleDataDoctor().doctors);
        }

        public IActionResult Appointment(int id)
        {
            SampleDataDoctor sample = new SampleDataDoctor();
            var doctor = sample.doctors.First(d => d.Id == id);
            return View(doctor);
        }
    }
}
