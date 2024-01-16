namespace SmartWebAppAPI.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IAuthRepository _authRepository;
    private readonly IAuthRoleRepository _roleRepository;
    private readonly IAuthTypeRepository _typeRepository;

    private readonly IQueryCountRepository _queryCountRepository;

    private readonly IUserResultRepository _userResultRepository;

    

    public RepositoryManager(RepositoryContext repositoryContext, IAuthRepository authRepository, IAuthRoleRepository roleRepository, IAuthTypeRepository typeRepository, IQueryCountRepository queryCountRepository, IUserResultRepository userResultRepository)
        {
            _repositoryContext = repositoryContext;
            _authRepository = authRepository;
        _roleRepository = roleRepository;
        _typeRepository = typeRepository;
        _queryCountRepository = queryCountRepository;
        _userResultRepository = userResultRepository;
    }

    public IAuthRepository AuthRepository => _authRepository;

    public IAuthRoleRepository AuthRoleRepository => _roleRepository;

    public IAuthTypeRepository AuthTypeRepository => _typeRepository;

    public IQueryCountRepository QueryCountRepository => _queryCountRepository;

    public IUserResultRepository UserResultRepository => _userResultRepository;

    public void Save()
        {
           _repositoryContext.SaveChanges();
        }
    }
}
