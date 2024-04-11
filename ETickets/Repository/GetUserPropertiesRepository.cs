using ETickets.Data;
using ETickets.IRepository;

namespace ETickets.Repository
{
    public class GetUserPropertiesRepository : IGetUserPropertiesRepository
    {
        private readonly ETicketsDbContext context;

        public GetUserPropertiesRepository(ETicketsDbContext context)
        {
            this.context = context;
        }

        public string GetUserImage(string id)
        {
            var image = context.Users.Where(u => u.Id == id).Select(u => u.Image).FirstOrDefault();
            if (image != null)
            {
                return image;
            }
            throw new NullReferenceException();
        }

        public string GetUserFirstName(string id) => context.Users.Where(u => u.Id == id).Select(u => u.FirstName).FirstOrDefault();
    }
}
