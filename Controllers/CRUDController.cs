using CRUD.Entities;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controller
{
#pragma warning disable 1591
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        [HttpPost("POST")]
        public IActionResult POSTASYNC([FromServices] ITarefaService _tarefaService)
        {
            var retorno = _tarefaService.AdicionarTarefasAsync();

            return Ok(retorno);
        }

        [HttpGet("GETALL")]
        public IEnumerable<Tarefa> GETALL([FromServices] ITarefaService _tarefaService)
        {
            var retorno = _tarefaService.BuscarTodas();

            return retorno;
        }

        [HttpGet("GET/{id}")]
        public IActionResult GET([FromServices] ITarefaService _tarefaService ,int id)
        {
            var retorno = _tarefaService.BuscarPorId(id);
            return Ok(retorno);
        }

        [HttpPut("PUT")]
        public string PUT()
        {
            return "Olá";
        }

        [HttpDelete("DELETE")]
        public string DELETE()
        {
            return "Olá";
        }
    }
}
