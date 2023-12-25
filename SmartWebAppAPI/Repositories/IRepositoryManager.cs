namespace SmartWebAppAPI.Repositories
{
    public interface IRepositoryManager
    {

       IAuthRepository AuthRepository { get; }
    IAuthRoleRepository AuthRoleRepository { get; }
    IAuthTypeRepository AuthTypeRepository { get; }

 


        void Save();
    }
}
