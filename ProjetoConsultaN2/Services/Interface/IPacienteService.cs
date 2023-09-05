
namespace ProjetoConsultaN2.Services.Interface
{
    public interface IPacienteService
    {
		Task<IEnumerable<PacienteDTO>> GetAllPacientesAsync();
		Task<List<PacienteDTO>> GetPacientesPorIdadeAsync(int idade);
		Task<List<ConsultaPorPacienteDTO>> GetConsultasPorPacienteAsync(int pacienteId);
		Task<PacienteDTO> UpdatePacienteAsync(int pacienteId, PacienteDTO request);
		Task<PacienteDTO> UpdatePacienteAddressAsync(int pacienteId, string request);
		Task<string> CreatePacienteAsync(CreatePacienteDTO request);
	}
}
