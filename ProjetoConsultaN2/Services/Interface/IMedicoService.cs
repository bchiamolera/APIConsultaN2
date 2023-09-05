using ProjetoConsultaN2.DTOs.Consultas;
using ProjetoConsultaN2.DTOs.Medicos;

namespace ProjetoConsultaN2.Services.Interface
{
    public interface IMedicoService
    {
        Task<List<MedicoDTO>?> GetAllMedicosAsync();
        Task<List<GetConsultaPacienteDTO>?> GetConsultasMedicoAsync(int id);
        Task<List<MedicoInfoDTO>?> GetMedicoEspecialidadeAsync(string especialidade);
        Task<List<MedicoInfoDTO>?> GetMedicosDisponiveisAsync(DateTime data, string especialidade);
        Task<Medico> PostMedicoAsync (PostMedicoDTO medicoDto);
        Task<Medico?> UpdateMedicoContactInfoAsync(MedicoContatoDTO medicoDto, int id);
        Task<Medico?> UpdateMedicoEspecialidadeAsync(MedicoEspecialidadeDTO medicoDto, int id);
    }
}
