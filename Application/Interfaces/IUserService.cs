using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService
{
    Task<bool> CreateUserAsync(RegisterUserDto regForm);
    Task<Tuple<User, bool>> VerifyPasswordAsync(LoginUserDto loginForm);
    Task<string> CreateTokenAsync(User user);
}