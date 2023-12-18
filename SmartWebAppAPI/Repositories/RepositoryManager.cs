namespace SmartWebAppAPI.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IAuthRepository _authRepository;

        public RepositoryManager(RepositoryContext repositoryContext, IAuthRepository authRepository)
        {
            _repositoryContext = repositoryContext;
            _authRepository = authRepository;
        }

        public IAuthRepository AuthRepository => _authRepository;

        public void Save()
        {
           _repositoryContext.SaveChanges();
        }
    }
}
