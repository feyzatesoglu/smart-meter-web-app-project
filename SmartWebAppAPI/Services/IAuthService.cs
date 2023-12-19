using Microsoft.AspNetCore.Mvc;
using SmartWebAppAPI.Entity.Dto;
using SmartWebAppAPI.Entity.Models;

namespace SmartWebAppAPI.Services
{
    public interface IAuthService
    {

        void CreateUser(RegisterDto registerDto);
        User? GetOneUserbyEmail(string email, bool trackChanges);
     
    }
}
