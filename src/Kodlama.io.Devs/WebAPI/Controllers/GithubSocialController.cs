using Application.Features.GithubProfiles.Commands.CreateGithubSocial;
using Application.Features.GithubProfiles.Commands.DeleteGithubSocial;
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
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubSocialController : BaseController
    {
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGithubSocialCommand createGithubSocialCommand)
        {
            CreateGithubSocialDto result = await Mediator.Send(createGithubSocialCommand);
            return Ok(result);
        }
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubSocialCommand updateGithubSocialCommand)
        {
            UpdatedGithubSocialDto result = await Mediator.Send(updateGithubSocialCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteGithubSocialCommand updateGithubSocialCommand)
        {
            var result = await Mediator.Send(updateGithubSocialCommand);
            return Ok(result);
        }
    }
}
