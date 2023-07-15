using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neoxim.Platform.Api.Constants;
using Neoxim.Platform.Core.Models;
using Neoxim.Platform.Core.Services;
using Neoxim.Platform.SharedKernel.Exceptions;

namespace Neoxim.Platform.Api.Controllers
{
    /// <summary>
    /// Users
    /// </summary>
    [ApiController]
    [Route("api/users")]
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUserAsync")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.GetAsync(id, cancellationToken);
                return Ok(result);
            }
            catch(ObjectNotFoundException ex)
            {
                return NotFound(ex.Error);
            }
        }

        /// <summary>
        /// Get users by tenant
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("tenant/{tenantId}", Name = "GetUsersByTenantAsync")]
        [ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsersByTenantAsync(Guid tenantId, CancellationToken cancellationToken)
        {
            var result = await _userService.GetListByTenantAsync(tenantId, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("", Name = "PostUserAsync")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = ClaimsConstant.Type.ADMIN)]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserModel model)
        {
            try
            {
                var result = await _userService.CreateAsync(model.FirstName, model.LastName, model.Gender, model.Email, model.Phone, model.Address, model.TenantId, model.Claims.ToList());
                return Ok(result);
            }
            catch(ObjectNotFoundException ex)
            {
                return BadRequest(ex.Error);
            }
            catch(ObjectAlreadyExistsException ex)
            {
                return BadRequest(ex.Error);
            }
        }

        /// <summary>
        /// Update user information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}", Name = "PatchUserAsync")]
        public async Task<IActionResult> PatchAsync(Guid id, [FromBody] UpdateUserModel model)
        {
            try
            {
                //var result = await _tenantService.GetAsync(id, cancellationToken);
                return Ok();
            }
            catch(ObjectNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteUserAsync")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                //var result = await _tenantService.GetAsync(id, cancellationToken);
                return Ok();
            }
            catch(ObjectNotFoundException)
            {
                return NotFound();
            }
        }
    }
}