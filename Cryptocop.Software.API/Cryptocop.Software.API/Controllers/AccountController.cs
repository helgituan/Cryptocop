using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult CreateUser([FromBody] RegisterInputModel inputModel)
        {
            var user = _accountService.CreateUser(inputModel);
            return StatusCode(201);
            //return Ok(_tokenService.GenerateJwtToken(user));
            //new StatusCodeResult(201);
        }

        [AllowAnonymous]
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
            return new EmptyResult();
        }

    }
}