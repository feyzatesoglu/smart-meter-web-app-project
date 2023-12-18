namespace SmartWebAppAPI.Repositories
{
    public interface IRepositoryManager
    {

       IAuthRepository AuthRepository { get; }

        void Save();
    }
}
