using BackendDataService.Models;
using BackendDataService.Models.Dto;

namespace WebApService.Services
{
    public interface IUsersService
    {
        Task CreateUserAsync(NewUserDto newUser);
        
        public Task<List<User>> GetAllUsersAsync();

    }
}