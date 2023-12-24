namespace SmartWebAppAPI.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IAuthRepository _authRepository;
    private readonly IAuthRoleRepository _roleRepository;
    private readonly IAuthTypeRepository _typeRepository;

    

    public RepositoryManager(RepositoryContext repositoryContext, IAuthRepository authRepository, 
    IAuthRoleRepository roleRepository, IAuthTypeRepository typeRepository)
    {
      _repositoryContext = repositoryContext;
      _authRepository = authRepository;
      _roleRepository = roleRepository;
      _typeRepository = typeRepository;
      
    }

    public IAuthRepository AuthRepository => _authRepository;

    public IAuthRoleRepository AuthRoleRepository => _roleRepository;

    public IAuthTypeRepository AuthTypeRepository => _typeRepository;

   

    public void Save()
        {
           _repositoryContext.SaveChanges();
        }
    }
}
