namespace ProjetoConsultaN2.DTOs.Consultas
{
    public class GetConsultaPacienteDTO
    {
        public DateTime DataConsulta { get; set; } = DateTime.MinValue;
        public string Descricao { get; set; } = string.Empty;
        public string Prescricao { get; set; } = string.Empty;
        public string TipoConsulta { get; set; } = string.Empty;
        public Paciente Paciente { get; set; }
    }
}
