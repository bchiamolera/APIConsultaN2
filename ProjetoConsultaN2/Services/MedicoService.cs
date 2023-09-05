using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ProjetoConsultaN2.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly DataContext _context;
        public MedicoService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MedicoDTO>?> GetAllMedicosAsync()
        {
            var medicos = await _context.Medicos.Select(m => new MedicoDTO
            {
                Id = m.Id,
                Nome = m.Nome,
                CRM = m.CRM,
                Especialidade = m.Especialidade,
                Telefone = m.Telefone,
                Endereco = m.Endereco,
                DataDeNascimento = m.DataDeNascimento,
                Sexo = m.Sexo,
                Idade = m.Idade,
                Pacientes = _context.Pacientes.Where(p => p.IdMedico == m.Id).Select(p => new CreatePacienteDTO
                {
                    Nome = p.Nome,
                    DataDeNascimento = p.DataDeNascimento,
                    CPF = p.CPF,
                    Telefone = p.Telefone,
                    Endereco = p.Endereco,
                    Sexo = p.Sexo,
                    TipoSanguineo = p.TipoSanguineo
                }).ToList(),
                Consultas = _context.Consultas.Where(c => c.IdMedico == m.Id).Select(c => new GetConsultaPacienteDTO
                {
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao,
                    Prescricao = c.Prescricao,
                    TipoConsulta = c.TipoConsulta,
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
                }).ToList()
            })
                .ToListAsync();
            if (medicos == null)
                return null;
            return medicos;
        }

        public async Task<List<GetConsultaPacienteDTO>?> GetConsultasMedicoAsync(int id)
        {
            var consultas = await _context.Consultas
                .Where(c => c.IdMedico == id)
                .Select(c => new GetConsultaPacienteDTO
                {
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao,
                    Prescricao = c.Prescricao,
                    TipoConsulta = c.TipoConsulta,
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

        public async Task<List<MedicoInfoDTO>?> GetMedicoEspecialidadeAsync(string especialidade)
        {
            var medicos = await _context.Medicos
                .Where(m => m.Especialidade == especialidade)
                .Select(m => new MedicoInfoDTO { 
                    Nome = m.Nome,
                    CRM = m.CRM,
                    Especialidade = m.Especialidade
                })
                .ToListAsync();
            if (medicos == null)
                return null;
            return medicos;
        }

        public async Task<List<MedicoInfoDTO>?> GetMedicosDisponiveisAsync(DateTime data, string especialidade)
        {
            var consultasData = await _context.Consultas.Where(c => !c.DataConsulta.Equals(data)).ToListAsync();
            var medicos = await _context.Medicos
                .Where(m => m.Especialidade == especialidade && m.Consultas.Equals(consultasData))
                .Select(m => new MedicoInfoDTO
                {
                    Nome = m.Nome,
                    CRM = m.CRM,
                    Especialidade = m.Especialidade
                })
                .ToListAsync();
            if (medicos == null)
                return null;
            return medicos;
        }

        public async Task<Medico> PostMedicoAsync(PostMedicoDTO medicoDto)
        {
            var medicoModel = new Medico
            {
                Nome = medicoDto.Nome,
                CRM = medicoDto.CRM,
                Especialidade = medicoDto.Especialidade,
                Telefone = medicoDto.Telefone,
                Endereco = medicoDto.Endereco,
                DataDeNascimento = medicoDto.DataDeNascimento,
                Sexo = medicoDto.Sexo,
                Idade = medicoDto.Idade
            };
            _context.Medicos.Add(medicoModel);
            await _context.SaveChangesAsync();
            return medicoModel;
        }

        public async Task<Medico?> UpdateMedicoContactInfoAsync(MedicoContatoDTO medicoDto, int id)
        {
            Medico medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
                return null;
            medico.Telefone = medicoDto.Telefone;
            medico.Endereco = medicoDto.Endereco;
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico?> UpdateMedicoEspecialidadeAsync(MedicoEspecialidadeDTO medicoDto, int id)
        {
            Medico medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
                return null;
            medico.Especialidade = medicoDto.Especialidade;
            await _context.SaveChangesAsync();
            return medico;
        }
    }
}
