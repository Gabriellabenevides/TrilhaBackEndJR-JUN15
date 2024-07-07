using GerenciadorTarefas.Domain.Interface.Service;
using GerenciadorTarefas.Model;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ILogger<TarefaController> _logger;
        private readonly ITarefaService _tarefaService;

        public TarefaController(ILogger<TarefaController> logger, ITarefaService tarefaService)
        {
            _logger = logger;
            _tarefaService = tarefaService;
        }

        [HttpPost(template: "Create")]
        public async Task<IActionResult> CreateTarefa([FromBody] Tarefa tarefa)
        {
            var result = await _tarefaService.Create(tarefa);
            return Ok(result);
        }

        [HttpPost(template: "Delete")]
        public async Task<IActionResult> DeleteTarefa([FromBody] int tarefaId)
        {
            if (tarefaId <= 0) { return BadRequest("Id da tarefa não deve ser menor que 1"); }

            var result = await _tarefaService.Delete(tarefaId);
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> ListTarefa()
        {
            try
            {
                var result = await _tarefaService.List();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(template: "Update")]
        public async Task<IActionResult> Update([FromBody] Tarefa tarefa)
        {
            var result = await _tarefaService.Update(tarefa);
            return Ok(result);
        }
    }
}
