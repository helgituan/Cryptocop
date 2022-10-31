using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
namespace Cryptocop.Software.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        public AccountController(ITokenService tokenService, IAccountService accountService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult CreateUser([FromBody] RegisterInputModel inputModel)
        {
            var user = _accountService.CreateUser(inputModel);
            return Ok(_tokenService.GenerateJwtToken(user));
            //new StatusCodeResult(201);
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult AuthenticateUser([FromBody] LoginInputModel inputModel)
        {
            var user = _accountService.AuthenticateUser(inputModel);
            if (user == null) { return Unauthorized(); }
            return Ok(_tokenService.GenerateJwtToken(user));
        }

        [HttpGet]
        [Route("signout")]
        public IActionResult Logout()
        {
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "tokenId").Value, out var tokenId);
            _accountService.Logout(tokenId);
            return NoContent();
        }

    }
}