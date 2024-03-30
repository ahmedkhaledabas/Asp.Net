using ETickets.IRepository;
using ETickets.Models;

namespace ETickets.Repository
{
    public class MovieRepository : IViewModelRepository<Models.Movie>
    {
        void IViewModelRepository<Movie>.Create(Movie viewModel)
        {
            throw new NotImplementedException();
        }

        void IViewModelRepository<Movie>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<Movie> IViewModelRepository<Movie>.ReadAll()
        {
            throw new NotImplementedException();
        }

        Movie IViewModelRepository<Movie>.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void IViewModelRepository<Movie>.Update(Movie viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
