using TaskManagement.API.DTOs;

namespace TaskManagement.API.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(CreateUserDto createUserDto);
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> GetUserByIdAsync(Guid userId);
    }
}