using ProjetoConsultaN2.DTOs.Consultas;

namespace ProjetoConsultaN2.Services.Interface
{
    public interface IConsultaService
    {
        Task<List<GetConsultaDTO>> GetAllConsultasAsync();
        Task<string> AgendarConsultaAsync(MarcarConsultaDTO consulta);
        Task<List<GetConsultaDTO>?> ListarConsultasPorDataAsync(DateTime data);
        Task<string?> DeleteConsultaAsync(int id);
    }
}
