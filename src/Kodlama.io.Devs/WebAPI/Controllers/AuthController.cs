using Application.Features.GithubSocials.Commands.CreateGithubSocial;
using Application.Features.GithubSocials.Dto;
using Application.Features.Languages.Commands.CreateProgrammingLanguage;
using Application.Features.Languages.Commands.DeleteProgrammingLanguage;
using Application.Features.Languages.Commands.UpdateProgrammingLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetByIdProgrammingLanguage;
using Application.Features.Languages.Queries.GetListProgrammingLanguage;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.Technologies.Queries.GetListTechnology;
using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using Core.Application.Requests;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginUserCommand loginUserCommand=new LoginUserCommand() { UserForLoginDto= userForLoginDto,IpAddress = GetIpAddress()};
            var result = await Mediator.Send(loginUserCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterUserCommand registerUserCommand = new() { IpAddress = GetIpAddress() , UserForRegisterDto = userForRegisterDto };
            RegisterUserDto result = await Mediator.Send(registerUserCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Ok( result);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
