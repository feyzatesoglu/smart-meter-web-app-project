using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Entity.Dto.AuthDto;
using SmartWebAppAPI.Entity.Models;
using SmartWebAppAPI.Repositories;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

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

      
        int? defaultUserType = _manager.AuthTypeRepository.GetTypeIdByName(registerDto.UserType);
      int? defaultUserRoleId = _manager.AuthRoleRepository.GetRoleIdByName(registerDto.Role);


      user.UserTypeId = defaultUserType ?? 0;
      user.RoleId = defaultUserRoleId ?? 0;






      _manager.AuthRepository.Add(user);
        _manager.Save();
      var user1=_manager.AuthRepository.GetOneUserbyEmail(registerDto.Email, trackChanges: false);

      _manager.QueryCountRepository.InsertQueryCountByUserId(user1.Id, registerDto.UserType);
      _manager.Save();
    }

    

    public User? GetOneUserbyEmail(string email, bool trackChanges)
        {
            var user = _manager.AuthRepository.GetOneUserbyEmail(email, trackChanges);     
            return user;
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

    public User?Login(string email, string password)
    {
      var user = _manager.AuthRepository.GetOneUserbyEmail(email, trackChanges: false);

      if (user != null && VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
      {
        return user;
      }

      return null;
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
      using (var sha256 = System.Security.Cryptography.SHA256.Create())
      {
        var combinedPassword = System.Text.Encoding.UTF8.GetBytes(password + Convert.ToBase64String(storedSalt));
        var hash = sha256.ComputeHash(combinedPassword);

        // Hesaplanan hash ile saklanan hash eşleşiyorsa doğrulama başarılıdır.
        return storedHash.SequenceEqual(hash);
      }
    }

    public IEnumerable<User> GetAllUsers()
    {
      return _manager.AuthRepository.GetAllUsers(false);

    }

    public void DeleteUser(int id)
    {
      User user = _manager.AuthRepository.GetOneUserbyId(id, false);

      if(user is not null){

        _manager.AuthRepository.DeleteUser(user);
        _manager.Save();
      }
    }

    public User? GetOneUserbyId(int id, bool trackChanges)
    {
      var user = _manager.AuthRepository.GetOneUserbyId(id, trackChanges);
      return user;
    }



    public GetUserForUpdateDto? GetUserByIdForUpdate(int id)
    {
      var user = _manager.AuthRepository.GetOneUserbyId(id, trackChanges: false);
      return _mapper.Map<GetUserForUpdateDto>(user);
    }

    public void UpdateUser(UpdateDto updateDto ,int id)
    {
      var user= _manager.AuthRepository.GetOneUserbyId(id, trackChanges: true);

      if (user == null)
      {
        // User not found logic
        return;
      }
      user.RoleId=_manager.AuthRoleRepository.GetRoleIdByName(updateDto.Role) ?? _manager.AuthRoleRepository.GetRoleIdByName("User");
      user.UserTypeId= _manager.AuthTypeRepository.GetTypeIdByName(updateDto.UserType) ?? 0;
      user.FirstName = updateDto.FirstName;
      user.LastName = updateDto.LastName;
       user.Email = updateDto.Email;

      
      
      _manager.AuthRepository.UpdateOneUser(user);
      _manager.Save();
    }
    public bool UpdatePassword(UpdatePasswordDto updatePasswordDto)
    {
      var user = _manager.AuthRepository.GetOneUserbyEmail(updatePasswordDto.email, trackChanges: false);
     

      if (user != null && VerifyPasswordHash(updatePasswordDto.OldPassword, user.PasswordHash, user.PasswordSalt))
      {
        byte[] passwordSalt = GeneratePasswordSalt();
        byte[] passwordHash = EncryptPassword(updatePasswordDto.NewPassword, passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _manager.AuthRepository.UpdateOneUser(user);
        _manager.Save();

        return true;
      }

      return false;
    }


    public void ForgetPassword(ForgetPasswordDto forgetPasswordDto)
    {
      // Implement your logic here for password recovery
      // For example, you can send a password reset link to the user's email
      // or generate a temporary password and send it to the user
      
      // Example implementation:
      var user = _manager.AuthRepository.GetOneUserbyEmail(forgetPasswordDto.email, trackChanges: false);
      
      if (user != null)
      {
        // Generate a temporary password
      
        
        // Update the user's password with the temporary password
        byte[] passwordSalt = GeneratePasswordSalt();
        byte[] passwordHash = EncryptPassword(forgetPasswordDto.password, passwordSalt);
        
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        
        _manager.AuthRepository.UpdateOneUser(user);
        _manager.Save();
        
        
      }
      else
      {
        
      }
    }
      
      public int? GetRoleIdByName(string roleName)
      {
        return _manager.AuthRoleRepository.GetRoleIdByName(roleName);
      }

public int? GetTypeById(string type)
{
  return _manager.AuthTypeRepository.GetTypeIdByName(type);
}


     
      public IQueryable<User> GetUsersByCondition(Expression<Func<User, bool>> condition)
    {
        return _manager.AuthRepository.GetUsersByCondition(condition);
    }
    
public string? GetRoleNameById(int roleId)
{
  return _manager.AuthRoleRepository.GetRoleNameById(roleId);
}

public string? GetTypeNameById(int typeId){
  return _manager.AuthTypeRepository.GetTypeNameById(typeId);
}





  }
}
