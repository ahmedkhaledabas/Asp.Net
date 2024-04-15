using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using NuGet.Frameworks;

namespace ETickets.Services
{
    public  class GetUserProperties
    {
        ETicketsDbContext context = new ETicketsDbContext();

        public string GetUserImage(string id)
        {
            return context.Users.Where(u => u.Id == id).Select(u => u.Image).FirstOrDefault();
        }
        public string GetUserFirstName(string id)
        {
            return context.Users.Where(u => u.Id == id).Select(u => u.FirstName).FirstOrDefault();
        }


    }
}
