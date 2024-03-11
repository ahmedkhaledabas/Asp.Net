using ContactDoctor.Models;
using Hospital.Models;
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



        public List<Reservation> _reservations = new List<Reservation>();
        public IActionResult Reservation()
        {

            return View("Reservation", _reservations);
        }


        [HttpGet]
        public IActionResult AddReservation(Reservation reservation)
        {
            _reservations.Add( new Reservation()
            {
                Patient = Request.Query["Patient"],
                Date = DateOnly.Parse(Request.Query["Date"]),
                Time = TimeOnly.Parse(Request.Query["Time"])
            });

            return View("Reservation", _reservations);
        }
    }
}
