using Application.Features.Language.Commands.CreateProgrammingLanguage;
using Application.Features.Language.Commands.DeleteProgrammingLanguage;
using Application.Features.Language.Commands.UpdateProgrammingLanguage;
using Application.Features.Language.Dtos;
using Application.Features.Language.Models;
using Application.Features.Language.Queries.GetByIdProgrammingLanguage;
using Application.Features.Language.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createSomeFeatureEntityCommand)
        {
            CreateProgrammingLanguageDto result = await Mediator.Send(createSomeFeatureEntityCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateSomeFeatureEntityCommand)
        {
            CreateProgrammingLanguageDto result = await Mediator.Send(updateSomeFeatureEntityCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> SoftDelete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            var result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListBrandQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getIdBrandQuery)
        {
            ProgrammingLanguageByIdDto brandGetByIdDto = await Mediator.Send(getIdBrandQuery);
            return Ok(brandGetByIdDto);
        }
    }
}
