using System.Linq.Expressions;
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
void ForgetPassword(ForgetPasswordDto forgetPasswordDto);
    
    UpdateDto? GetUserByIdForUpdate(int id);
    void UpdateUser(UpdateDto updateDto);
    bool UpdatePassword(UpdatePasswordDto updatePasswordDto);
    IQueryable<User> GetUsersByCondition(Expression<Func<User, bool>> condition);

     int? GetRoleIdByName(string roleName);
      

 int? GetTypeById(string type);

  

}



  }

