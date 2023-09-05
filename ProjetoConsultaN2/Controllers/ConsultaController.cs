using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoConsultaN2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;
        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllConsultas()
        {
            var consultas = await _consultaService.GetAllConsultasAsync();
            if (consultas == null) 
                return NotFound("Nenhuma consulta encontrada.");
            return Ok(consultas);
        }

        [HttpPost]
        public async Task<IActionResult> AgendarConsulta(MarcarConsultaDTO consultaDto) {
            var consulta = await _consultaService.AgendarConsultaAsync(consultaDto);
            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta(int id)
        {
            var consulta = await _consultaService.DeleteConsultaAsync(id);
            if (consulta == null)
                return NotFound("Consulta não encontrada.");
            return Ok(consulta);
        }

        [HttpGet("{data}")]
        public async Task<IActionResult> GetConsultasByData(DateOnly data)
        {
            var consultas = await _consultaService.ListarConsultasPorDataAsync(data);
            if (consultas == null)
                return NotFound("Nenhuma consulta encontrada.");
            return Ok(consultas);
        }
    }
}
