﻿namespace ETickets.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Bio { get; set; } = null!;

        public string? ProfilePicture { get; set; } 

        public string? News { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
