using System;

namespace ETickets.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; } = null !;
        public string Description { get; set; } = null!;

        public decimal Price { get; set; }
        public string ImgUrl { get; set; } = null!;

        public string TrailerUrl { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate {  get; set; }
        public MovieStatus MovieStatus { get; set; }
        public int CinemaId { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public Cinema Cinema { get; set; }
        public List<Actor> Actors { get; set; }

        public List<Ticket> Tickets { get; set; }

    }
}
