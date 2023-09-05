using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoConsultaN2.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.MinValue;
        public string Descricao { get; set; } = string.Empty;
        public string Prescricao { get; set; } = string.Empty;
        public string TipoConsulta { get; set; } = string.Empty;
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }

        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
