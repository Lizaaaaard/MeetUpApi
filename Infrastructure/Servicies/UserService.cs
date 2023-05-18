using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Dto;
using Microsoft.AspNetCore.Identity;
using Persistance;

namespace Infrastructure.Servicies;

public class UserService:IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly AppDbContext _ctx;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext ctx)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _ctx = ctx;
    }

    public async Task<bool> CreateUserAsync(RegisterUserDto regForm)
    {
        try
        {
            var user = new User
            {
                UserName = regForm.UserName,
                Email = regForm.Email,
                PhoneNumber = regForm.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, regForm.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); return false; }

    }

    public async Task<Tuple<User, bool>> VerifyPasswordAsync(LoginUserDto loginForm)
    {
        User user = _ctx.Users.SingleOrDefault(x => x.UserName == loginForm.UserName);
        if (user == null)
            return Tuple.Create(user, false);
        await _signInManager.PasswordSignInAsync(user, loginForm.Password, true, false);
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginForm.Password, false);
        return Tuple.Create(user, result.Succeeded);
    }
}