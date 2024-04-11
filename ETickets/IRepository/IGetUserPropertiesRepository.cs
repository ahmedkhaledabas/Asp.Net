namespace ETickets.IRepository
{
    public interface IGetUserPropertiesRepository
    {
        string GetUserImage(string id);
        string GetUserFirstName(string id);
    }
}
