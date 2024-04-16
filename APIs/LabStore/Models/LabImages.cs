namespace LabStore.Models
{
    public class LabImages
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int LabId { get; set; }
        public Labtop Labtop { get; set; }
    }
}
