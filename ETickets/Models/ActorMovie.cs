using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets.Models
{
    public class ActorMovie
    {
       
        public int ActorsId { get; set; }
       
        public int MoviesId { get; set; }

       

    }
}
