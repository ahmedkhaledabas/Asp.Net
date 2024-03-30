namespace ETickets.IRepository
{
    public interface IViewModelRepository<T> where T : class
    {
        void Delete(int id);

        void Update(T viewModel);

        List<T> ReadAll();
        T ReadById(int id);

        void Create(T viewModel);
    }
}
