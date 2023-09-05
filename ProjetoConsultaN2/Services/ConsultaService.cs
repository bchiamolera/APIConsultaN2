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
                    Medico = new MedicoInfoDTO
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

        public async Task<string> AgendarConsultaAsync(MarcarConsultaDTO consulta)
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

<<<<<<< HEAD
            return "Consulta agendada com sucesso";
=======
            var response = new GetConsultaDTO
            {
                Id = consultaModel.Id,
                DataConsulta = consultaModel.DataConsulta,
                Descricao = consultaModel.Descricao,
                Prescricao = consultaModel.Prescricao,
                TipoConsulta = consultaModel.TipoConsulta,
                Medico = new MedicoInfoDTO
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
>>>>>>> e2e76e85a884363ff878716c07743a712d7defee
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
                    Medico = new MedicoInfoDTO
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
