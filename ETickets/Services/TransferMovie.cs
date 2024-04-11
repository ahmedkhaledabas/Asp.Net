using ETickets.Models;
using ETickets.ViewModels;

namespace ETickets.Services
{
    public static class TransferMovie
    {
        public static MovieViewModel MovieToMovieVM(Movie movie)
        {
                var movieViewModel = new MovieViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                CategoryId = movie.CategoryId,
                CinemaId = movie.CinemaId,
                ImgUrl = movie.ImgUrl,
                TrailerUrl = movie.TrailerUrl,
                Price = movie.Price

            };
                return movieViewModel;
        }


        public static Movie VMToMovie(MovieViewModel movieViewModel)
        {
                var movie = new Movie()
                {
                    Id = movieViewModel.Id,
                    Name = movieViewModel.Name,
                    Description = movieViewModel.Description,
                    StartDate = movieViewModel.StartDate,
                    EndDate = movieViewModel.EndDate,
                    CategoryId = movieViewModel.CategoryId,
                    CinemaId = movieViewModel.CinemaId,
                    ImgUrl = movieViewModel.ImgUrl,
                    TrailerUrl = movieViewModel.TrailerUrl,
                    Price = movieViewModel.Price
                };
                return movie;
        }
    }
}
