using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoConsultaN2.Models;

namespace ProjetoConsultaN2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMedicos() {
            var medicos = await _medicoService.GetAllMedicosAsync();
            if (medicos == null) 
                return NotFound("Nenhum médico encontrado.");
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsultasByMedico(int id)
        {
            var consultas = await _medicoService.GetConsultasMedicoAsync(id);
            if (consultas == null)
                return NotFound("Nenhuma consulta encontrado.");
            return Ok(consultas);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicoContactInfo(MedicoContatoDTO medicoDto, int id)
        {
            var medico = await _medicoService.UpdateMedicoContactInfoAsync(medicoDto, id);
            if (medico == null)
                return NotFound("Médico não encontrado.");
            return Ok(medico);
        }

        [HttpGet("{especialidade}")]
        public async Task<IActionResult> GetMedicosByEspecialidade([FromQuery] string especialidade)
        {
            var medicos = await _medicoService.GetMedicoEspecialidadeAsync(especialidade);
            if (medicos == null)
                return NotFound("Nenhum médico encontrado.");
            return Ok(medicos);
        }

        [HttpPost]
        public async Task<IActionResult> PostMedico(MedicoDTO medicoDto)
        {
            var medico = await _medicoService.PostMedicoAsync(medicoDto);
            return Ok(medico);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMedicoEspecialidade(MedicoEspecialidadeDTO medicoDto, int id)
        {
            var medico = await _medicoService.UpdateMedicoEspecialidadeAsync(medicoDto, id);
            if (medico == null)
                return NotFound("Médico não encontrado");
            return Ok(medico);
        }

        [HttpGet("disponiveis")]
        public async Task<IActionResult> GetMedicosDisponiveis([FromQuery] DateOnly data, [FromQuery] string especialidade)
        {
            var medicos = await _medicoService.GetMedicosDisponiveisAsync(data, especialidade);
            if (medicos == null)
                return NotFound("Nenhum médico disponível");
            return Ok(medicos);
        }
    }
}
