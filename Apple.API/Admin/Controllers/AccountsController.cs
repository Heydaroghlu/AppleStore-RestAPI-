
using Apple.Core.Entities;
using Apple.Core.UnitOfWork;
using Apple.Data.UnitOfWork;
using Apple.Service.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Apple.API.Admin.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountsController(IUnitOfWork unitOf,IConfiguration configuration,RoleManager<IdentityRole> roleManager,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _unitOfWork=unitOf;
            _userManager=userManager;
            _signInManager=signInManager;
            _configuration=configuration;
            _roleManager=roleManager;   
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            var user =await Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("Ad vey Sifre yanlishdir!");
        }
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var adminRoles = _userManager.GetRolesAsync(user).Result;
            var roleClaims = adminRoles.Select(x => new Claim(ClaimTypes.Role, x));
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email,user.Email),
            };
            claims.AddRange(roleClaims);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"]
                ,claims,expires:DateTime.UtcNow.AddMinutes(5),signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        private async Task<User> Authenticate(UserLoginDTO userLogin)
        {
            User search = await _userManager.FindByNameAsync(userLogin.UserName);

            var result = await _signInManager.PasswordSignInAsync(search, userLogin.Password,false,false);
            if(search!=null && result.Succeeded)
            {
                return search;
            }
            return null;
        }
        [HttpGet("ForAdmin")]
        [Authorize(Roles ="Admin")]
        public IActionResult ForAdmin()
        {
            UserLoginDTO currentUser = CurrentUser();

            return Ok($"Hi {currentUser.UserName}, you are an {currentUser.Password}");
        }
        private UserLoginDTO CurrentUser()
        {
            var identity=HttpContext.User.Identity as ClaimsIdentity;
            if(identity!=null)
            {
                var userClaims = identity.Claims;
                return new UserLoginDTO()
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                };
            }
            return null;
        }
        /*[HttpGet("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin()
        {
            User Admin = new User
            {
                UserName = "Admin",
                Name = "Isa",
                Surname = "Heydaroghlu",
                PhoneNumber = "+994 77 710 0910",
                Email="isaheydaroghlu@gmail.com",
                IsDelete = false
              
            };
            var result =await _userManager.CreateAsync(Admin, "Admin0910");
            await _userManager.AddToRoleAsync(Admin,"Admin");
            return Ok(result);
         }*/
        /*[HttpGet("CreateRole")]
        public async Task<IActionResult> CreateRoles()
        {
            var result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Member"));
            await _unitOfWork.Commit();
            return Ok(result);
        }*/
    }
}
