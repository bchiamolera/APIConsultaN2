using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoConsultaN2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
		public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetAllPacientes()
        {
            var pacientes = await _pacienteService.GetAllPacientesAsync();
            if(pacientes == null)
            {
                return NotFound("Nenhum paciente foi encontrado");
            }
            return Ok(pacientes);
        }

		[HttpGet("idade")]
		public async Task<ActionResult<List<PacienteDTO>>> GetPacientesPorIdade([FromQuery] int idade_maior_que)
        {
			var pacientes = await _pacienteService.GetPacientesPorIdadeAsync(idade_maior_que);
			if (pacientes == null)
			{
				return NotFound("Nenhum paciente foi encontrado");
			}
			return Ok(pacientes);
		}

		[HttpGet("{id}/consultas")]
		public async Task<ActionResult<List<ConsultaPorPacienteDTO>>> GetConsultasPorPaciente(int id)
        {
			var consultas = await _pacienteService.GetConsultasPorPacienteAsync(id);
			if (consultas == null)
			{
				return NotFound("Nenhuma consulta foi encontrada");
			}
			return Ok(consultas);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<PacienteDTO>> UpdatePaciente(int id, PacienteDTO request)
        {
			var pacientes = await _pacienteService.UpdatePacienteAsync(id, request);
			if (pacientes == null)
			{
				return NotFound("Nenhum paciente foi encontrado");
			}
			return Ok(pacientes);
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult<PacienteDTO>> UpdatePacienteAddress(int id, string request)
        {
			var pacientes = await _pacienteService.UpdatePacienteAddressAsync(id, request);
			if (pacientes == null)
			{
				return NotFound("Nenhum paciente foi encontrado");
			}
			return Ok(pacientes);
		}

		[HttpPost]
        public async Task<ActionResult<string>> CreatePaciente(CreatePacienteDTO request)
        {
			var paciente = await _pacienteService.CreatePacienteAsync(request);
			return Ok(paciente);
		}
	}
}
