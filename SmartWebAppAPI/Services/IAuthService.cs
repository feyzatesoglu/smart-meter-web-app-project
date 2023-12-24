using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Entity.Dto.AuthDto;
using SmartWebAppAPI.Entity.Models;

namespace SmartWebAppAPI.Services
{
  public interface IAuthService
    {

        void CreateUser(RegisterDto registerDto);
        User? GetOneUserbyEmail(string email, bool trackChanges);
         User? GetOneUserbyId(int id, bool trackChanges);
       User? Login(string email, string password);
        IEnumerable<User> GetAllUsers();

        void DeleteUser(int id);

    
    UpdateDto? GetUserByIdForUpdate(int id);
    void UpdateUser(UpdateDto updateDto);
    bool UpdatePassword(UpdatePasswordDto updatePasswordDto);




  }
}
