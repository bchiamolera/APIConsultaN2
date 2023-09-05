using ProjetoConsultaN2.DTOs.Consultas;
using ProjetoConsultaN2.DTOs.Medicos;

namespace ProjetoConsultaN2.Services.Interface
{
    public interface IMedicoService
    {
        Task<List<Medico>?> GetAllMedicosAsync();
        Task<List<GetConsultaPacienteDTO>?> GetConsultasMedicoAsync(int id);
        Task<List<GetMedicoDTO>?> GetMedicoEspecialidadeAsync(string especialidade);
        Task<List<GetMedicoDTO>?> GetMedicosDisponiveisAsync(DateTime data, string especialidade);
        Task<Medico> PostMedicoAsync (MedicoDTO medicoDto);
        Task<Medico?> UpdateMedicoContactInfoAsync(MedicoContatoDTO medicoDto, int id);
        Task<Medico?> UpdateMedicoEspecialidadeAsync(MedicoEspecialidadeDTO medicoDto, int id);
    }
}
