using IEAMicroService.IdentityServer.Dtos.UserDtos;
using IEAMicroService.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace IEAMicroService.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser()
            {
                NameSurname = signUpDto.NameSurname,
                UserName = signUpDto.Username,
                Email = signUpDto.Email,
                City = signUpDto.City
            };
            await _userManager.CreateAsync(user,signUpDto.Password);
            return Ok("Kayıt Başarıyla Oluşturuldu");
        }
    }
}
