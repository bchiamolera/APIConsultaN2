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

        public async Task<List<Medico>?> GetAllMedicosAsync()
        {
            var medicos = await _context.Medicos.ToListAsync();
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
                    Paciente = c.Paciente,
                })
                .ToListAsync();
            if (consultas == null)
                return null;
            return consultas;
        }

        public async Task<List<GetMedicoDTO>?> GetMedicoEspecialidadeAsync(string especialidade)
        {
            var medicos = await _context.Medicos
                .Where(m => m.Especialidade == especialidade)
                .Select(m => new GetMedicoDTO { 
                    Nome = m.Nome,
                    CRM = m.CRM,
                    Especialidade = m.Especialidade
                })
                .ToListAsync();
            if (medicos == null)
                return null;
            return medicos;
        }

        public async Task<List<GetMedicoDTO>?> GetMedicosDisponiveisAsync(DateOnly data, string especialidade)
        {
            var consultasData = await _context.Consultas.Where(c => !c.DataConsulta.Equals(data)).ToListAsync();
            var medicos = await _context.Medicos
                .Where(m => m.Especialidade == especialidade && m.Consultas.Equals(consultasData))
                .Select(m => new GetMedicoDTO
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

        public async Task<Medico> PostMedicoAsync(MedicoDTO medicoDto)
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
