using GerenciadorTarefas.Domain.Interface.Service;
using GerenciadorTarefas.Domain.Service;
using GerenciadorTarefas.Model;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost(template: "Create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var result = await _userService.Create(user);
            return Ok(result);
        }

        [HttpPost(template: "Delete")]
        public async Task<IActionResult> DeleteUser([FromBody] int userId)
        {
            if (userId <= 0) { return BadRequest("Id do usuário não deve ser menor que 1"); }

            var result = await _userService.Delete(userId);
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> ListUser()
        {
            try
            {
                var result = await _userService.List();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(template: "Update")]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            var result = await _userService.Update(user);
            return Ok(result);
        }
    }
}
