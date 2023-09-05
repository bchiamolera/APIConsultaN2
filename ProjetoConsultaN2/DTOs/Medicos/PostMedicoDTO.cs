namespace ProjetoConsultaN2.DTOs.Medicos
{
    public class PostMedicoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public int CRM { get; set; } = 0;
        public string Especialidade { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; } = DateTime.MinValue;
        public string Sexo { get; set; } = string.Empty;
        public int Idade { get; set; } = 0;
    }
}
