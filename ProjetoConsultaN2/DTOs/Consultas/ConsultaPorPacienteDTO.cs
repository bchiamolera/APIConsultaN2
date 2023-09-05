namespace ProjetoConsultaN2.DTOs.Consultas
{
	public class ConsultaPorPacienteDTO
	{
        public DateTime DataConsulta { get; set; } = DateTime.MinValue;
        public string Descricao { get; set; } = string.Empty;
		public string Prescricao { get; set; } = string.Empty;
		public string TipoConsulta { get; set; } = string.Empty;
        public int IdPaciente { get; set; } = 0;
        public MedicoInfoDTO Medico { get; set; }
	}
}
