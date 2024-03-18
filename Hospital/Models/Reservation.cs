namespace Hospital.Models
{
    public class Reservation
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string Patient { get; set; }

        public string DoctorName {  get; set; }
    }
}
