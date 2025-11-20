using Application.Models;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace tpi_GasparOneto_2024_programacion3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetById(id);

                return Ok(new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Rol = user.Rol,
                });
            }

            catch
            {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto)
        {

            try
            {
                var newUser = _userService.AddUser(userDto);
                return Ok(newUser);
            }
            catch
            {

                return BadRequest();

            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var rol = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            if (rol != "ADMIN")
                return Forbid();

            try
            {
                await _userService.DeleteByIdAsync(id);
                return Ok();
            }

            catch
            {
                return BadRequest();
            }
        }
    }
}
