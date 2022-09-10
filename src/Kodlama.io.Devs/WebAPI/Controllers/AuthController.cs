using Application.Features.GithubProfiles.Commands.CreateGithubSocial;
using Application.Features.GithubProfiles.Dto;
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
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            LoginUserDto result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            RegisterUserDto result = await Mediator.Send(registerUserCommand);
            return Ok( result);
        }
    }
}
