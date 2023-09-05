namespace ProjetoConsultaN2.DTOs.Consultas
{
    public class GetConsultaDTO
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.MinValue;
        public string Descricao { get; set; } = string.Empty;
        public string Prescricao { get; set; } = string.Empty;
        public string TipoConsulta { get; set; } = string.Empty;

        public MedicoInfoDTO Medico { get; set; }
        public CreatePacienteDTO Paciente { get; set; }
    }
}
