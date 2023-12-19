using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Entity.Dto;
using SmartWebAppAPI.Entity.Models;
using SmartWebAppAPI.Repositories;

namespace SmartWebAppAPI.Services
{
    public class AuthManager : IAuthService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AuthManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }


    public void CreateUser(RegisterDto registerDto)
    {
      // AutoMapper ile RegisterDto'dan User nesnesine dönüşüm yapılıyor
      var user = _mapper.Map<User>(registerDto);

      // Kullanıcı için şifre ve tuz oluşturuluyor
      byte[] passwordSalt = GeneratePasswordSalt();
      byte[] passwordHash = EncryptPassword(registerDto.Password, passwordSalt);

      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;
      user.CreatedDate = DateTime.UtcNow;
     
      
      var defaultUserType = _manager.AuthTypeRepository.GetTypeIdByName(registerDto.UserType);
      var defaultUserRoleId = _manager.AuthRoleRepository.GetRoleIdByName(registerDto.Role);

   
      
      user.UserTypeId = defaultUserType ?? 1; // Varsayılan bir ID
      user.RoleId = defaultUserRoleId ?? 1; // Varsayılan bir ID

      _manager.AuthRepository.Add(user);
      _manager.Save();
    }

    

    public User? GetOneUserbyEmail(string email, bool trackChanges)
        {
            var product = _manager.AuthRepository.GetOneUser(email, trackChanges);     
            return product;
        }

        private byte[] EncryptPassword(string password, byte[] salt)
        {
            // Burada güvenli bir şifreleme algoritması kullanılmalıdır (örneğin: PBKDF2, bcrypt, Argon2)
            // Örnek olarak SHA256 kullanıldı. Gerçek uygulamada güvenli bir algoritma kullanılmalıdır.
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var combinedPassword = System.Text.Encoding.UTF8.GetBytes(password + Convert.ToBase64String(salt));
                return sha256.ComputeHash(combinedPassword);
            }
        }

        // Rastgele tuz oluşturma
        private byte[] GeneratePasswordSalt()
        {
            var salt = new byte[32];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
