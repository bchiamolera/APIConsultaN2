using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoConsultaN2.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; } = DateTime.MinValue;
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string TipoSanguineo { get; set; } = string.Empty;

        public int IdMedico { get; set; }
        public virtual Medico Medico { get; set; }
    }
}
