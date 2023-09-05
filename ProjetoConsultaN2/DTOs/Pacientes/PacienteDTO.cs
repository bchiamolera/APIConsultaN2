namespace ProjetoConsultaN2.DTOs.Pacientes
{
    public class PacienteDTO
    {
		public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public DateTime DataDeNascimento { get; set; } = DateTime.MinValue;
		public string CPF { get; set; } = string.Empty;
		public string Telefone { get; set; } = string.Empty;
		public string Endereco { get; set; } = string.Empty;
		public string Sexo { get; set; } = string.Empty;
		public string TipoSanguineo { get; set; } = string.Empty;

		public MedicoInfoDTO Medico { get; set; }
	}
}
