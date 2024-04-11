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


        //IGetUserPropertiesRepository getUserPropertiesRepository;

        //public GetUserProperties() { }
        //public GetUserProperties(IGetUserPropertiesRepository getUserPropertiesRepository)
        //{
        //    this.getUserPropertiesRepository = getUserPropertiesRepository;
        //}

        //public string GetUserImage(string id)
        //{
        //    var image = getUserPropertiesRepository.GetUserImage(id);
        //    return image;
        //}

        //public string GetUserFirstName(string id) => getUserPropertiesRepository.GetUserFirstName(id);
    }
}
