using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistance;

namespace Infrastructure.Servicies;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _ctx;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, AppDbContext ctx)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _ctx = ctx;
    }

    public async Task<bool> CreateUserAsync(RegisterUserDto regForm)
    {
        try
        {
            CreatePasswordHash(regForm.Password, out byte[] passwordHash, out byte[] passwordSalt);

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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
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

    public async Task<string> CreateTokenAsync(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("name", user.UserName),
            new Claim("id", user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}