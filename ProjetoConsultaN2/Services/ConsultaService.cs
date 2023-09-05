using Microsoft.EntityFrameworkCore;

namespace ProjetoConsultaN2.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly DataContext _context;
        public ConsultaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GetConsultaDTO>> GetAllConsultasAsync()
        {
            var consultas = await _context.Consultas
                .Select(c => new GetConsultaDTO
                {
                    Id = c.Id,
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao,
                    Prescricao = c.Prescricao,
                    TipoConsulta = c.TipoConsulta,
                    Medico = new GetMedicoDTO
                    {
                        Nome = c.Medico.Nome,
                        CRM = c.Medico.CRM,
                        Especialidade = c.Medico.Especialidade
                    },
                    Paciente = new CreatePacienteDTO
                    {
                        Nome = c.Paciente.Nome,
                        DataDeNascimento = c.Paciente.DataDeNascimento,
                        CPF = c.Paciente.CPF,
                        Telefone = c.Paciente.Telefone,
                        Endereco = c.Paciente.Endereco,
                        Sexo = c.Paciente.Sexo,
                        TipoSanguineo = c.Paciente.TipoSanguineo
                    }
                })
                .ToListAsync();
            if (consultas == null)
                return null;
            return consultas;
        }

        public async Task<GetConsultaDTO> AgendarConsultaAsync(MarcarConsultaDTO consulta)
        {
            var consultaModel = new Consulta() {
                DataConsulta = consulta.DataConsulta,
                Descricao = consulta.Descricao,
                Prescricao = consulta.Prescricao,
                TipoConsulta = consulta.TipoConsulta,
                IdMedico = consulta.IdMedico,
                IdPaciente = consulta.IdPaciente
            };
            _context.Consultas.Add(consultaModel);
            await _context.SaveChangesAsync();

            var response = new GetConsultaDTO
            {
                Id = consultaModel.Id,
                DataConsulta = consultaModel.DataConsulta,
                Descricao = consultaModel.Descricao,
                Prescricao = consultaModel.Prescricao,
                TipoConsulta = consultaModel.TipoConsulta,
                Medico = new GetMedicoDTO
                {
                    Nome = consultaModel.Medico.Nome,
                    CRM = consultaModel.Medico.CRM,
                    Especialidade = consultaModel.Medico.Especialidade
                },
                Paciente = new CreatePacienteDTO
                {
                    Nome = consultaModel.Paciente.Nome,
                    DataDeNascimento = consultaModel.Paciente.DataDeNascimento,
                    CPF = consultaModel.Paciente.CPF,
                    Telefone = consultaModel.Paciente.Telefone,
                    Endereco = consultaModel.Paciente.Endereco,
                    Sexo = consultaModel.Paciente.Sexo,
                    TipoSanguineo = consultaModel.Paciente.TipoSanguineo
                }
            };
            return response;
        }

        public async Task<string?> DeleteConsultaAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
                return null;
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return "Consulta deletada com sucesso.";
        }

        public async Task<List<GetConsultaDTO>?> ListarConsultasPorDataAsync(DateOnly data)
        {
            var consultas = await _context.Consultas
                .Where(c => c.DataConsulta.Equals(data))
                .Select(c => new GetConsultaDTO
                {
                    Id = c.Id,
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao,
                    Prescricao = c.Prescricao,
                    TipoConsulta = c.TipoConsulta,
                    Medico = new GetMedicoDTO
                    {
                        Nome = c.Medico.Nome,
                        CRM = c.Medico.CRM,
                        Especialidade = c.Medico.Especialidade
                    },
                    Paciente = new CreatePacienteDTO
                    {
                        Nome = c.Paciente.Nome,
                        DataDeNascimento = c.Paciente.DataDeNascimento,
                        CPF = c.Paciente.CPF,
                        Telefone = c.Paciente.Telefone,
                        Endereco = c.Paciente.Endereco,
                        Sexo = c.Paciente.Sexo,
                        TipoSanguineo = c.Paciente.TipoSanguineo
                    }
                })
                .ToListAsync();
            if (consultas == null)
                return null;
            return consultas;
        }
    }
}
