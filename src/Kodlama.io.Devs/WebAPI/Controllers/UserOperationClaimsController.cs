using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaimCommand;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaimCommand;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            var result = await Mediator.Send(createUserOperationClaimCommand);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            var result = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(result);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            DeleteUserOperationClaimCommand deleteUserOperationClaimCommand = new() { Id = Id };
            var result = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(result);
        }

        [HttpGet("claimListByUserId/{UserId}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetClaimListByUserId([FromRoute] int UserId)
        {
            GetListUserOperationClaimByUserIdQuery getListUserOperationClaimByUserIdQuery = new() { UserId = UserId };
            var result = await Mediator.Send(getListUserOperationClaimByUserIdQuery);
            return Ok(result);
        }
    }
}
