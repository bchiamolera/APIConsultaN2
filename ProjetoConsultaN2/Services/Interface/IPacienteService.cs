
namespace ProjetoConsultaN2.Services.Interface
{
    public interface IPacienteService
    {
		Task<IEnumerable<PacienteDTO>> GetAllPacientesAsync();
		Task<List<PacienteDTO>> GetPacientesPorIdadeAsync(int idade);
		Task<List<ConsultaPorPacienteDTO>> GetConsultasPorPacienteAsync(int pacienteId);
		Task<string> UpdatePacienteAsync(int pacienteId, PacienteTelefoneDTO request);
		Task<string> UpdatePacienteAddressAsync(int pacienteId, PacienteEnderecoDTO request);
		Task<string> CreatePacienteAsync(CreatePacienteDTO request);
	}
}
