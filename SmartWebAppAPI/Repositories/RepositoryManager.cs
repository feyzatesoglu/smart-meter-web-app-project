namespace SmartWebAppAPI.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IAuthRepository _authRepository;
    private readonly IAuthRoleRepository _roleRepository;
    private readonly IAuthTypeRepository _typeRepository;

    private readonly IQueryCountRepository _queryCountRepository;

    

    public RepositoryManager(RepositoryContext repositoryContext, IAuthRepository authRepository, IAuthRoleRepository roleRepository, IAuthTypeRepository typeRepository, IQueryCountRepository queryCountRepository)
        {
            _repositoryContext = repositoryContext;
            _authRepository = authRepository;
        _roleRepository = roleRepository;
        _typeRepository = typeRepository;
        _queryCountRepository = queryCountRepository;
    }

    public IAuthRepository AuthRepository => _authRepository;

    public IAuthRoleRepository AuthRoleRepository => _roleRepository;

    public IAuthTypeRepository AuthTypeRepository => _typeRepository;

    public IQueryCountRepository QueryCountRepository => _queryCountRepository;

    public void Save()
        {
           _repositoryContext.SaveChanges();
        }
    }
}
