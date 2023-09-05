using Microsoft.EntityFrameworkCore;

namespace ProjetoConsultaN2.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly DataContext _context;
        public PacienteService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> CreatePacienteAsync(CreatePacienteDTO request)
        {
            var paciente = new Paciente
            {
                Nome = request.Nome,
                DataDeNascimento = request.DataDeNascimento,
                CPF = request.CPF,
                Telefone = request.Telefone,
                Endereco = request.Endereco,
                Sexo = request.Sexo,
                TipoSanguineo = request.TipoSanguineo
            };
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return "Paciente criado com sucesso";
        }

        public async Task<IEnumerable<PacienteDTO>> GetAllPacientesAsync()
        {
            var pacientes = await _context.Pacientes
                .Include(p => p.Medico)
                .Select(p => new PacienteDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    DataDeNascimento = p.DataDeNascimento,
                    CPF = p.CPF,
                    Telefone = p.Telefone,
                    Endereco = p.Endereco,
                    Sexo = p.Sexo,
                    TipoSanguineo = p.TipoSanguineo,
                    Medico = new GetMedicoDTO
                    {
                        Nome = p.Medico.Nome,
                        CRM = p.Medico.CRM,
                        Especialidade = p.Medico.Especialidade,
                    }
                }).ToListAsync();
            if (pacientes == null) return null;

            return pacientes;
        }

        public async Task<List<ConsultaPorPacienteDTO>> GetConsultasPorPacienteAsync(int pacienteId)
        {
            var consultas = await _context.Consultas
                .Select(c => new ConsultaPorPacienteDTO
                {
                    DataConsulta = c.DataConsulta,
                    Descricao = c.Descricao,
                    Prescricao = c.Prescricao,
                    TipoConsulta = c.TipoConsulta,
                    PacienteId = c.Paciente.Id
                }).Where(c => c.PacienteId == pacienteId).ToListAsync();
            if (consultas == null) return null;
            return consultas;
		}

        public async Task<List<PacienteDTO>> GetPacientesPorIdadeAsync(int idade)
        {
			var pacientes = await _context.Pacientes
				.Include(p => p.Medico)
				.Select(p => new PacienteDTO
				{
					Id = p.Id,
					Nome = p.Nome,
					DataDeNascimento = p.DataDeNascimento,
					CPF = p.CPF,
					Telefone = p.Telefone,
					Endereco = p.Endereco,
					Sexo = p.Sexo,
					TipoSanguineo = p.TipoSanguineo,
					Medico = new GetMedicoDTO
					{
						Nome = p.Medico.Nome,
						CRM = p.Medico.CRM,
						Especialidade = p.Medico.Especialidade,
					}
				}).Where(p => (DateTime.Now.Year - p.DataDeNascimento.Year) > idade).ToListAsync();
			if (pacientes == null) return null;
			return pacientes;
		}

        public async Task<PacienteDTO> UpdatePacienteAddressAsync(int pacienteId, string request)
        {
			var paciente = await _context.Pacientes
				.Include(p => p.Medico)
				.Select(p => new PacienteDTO
				{
					Id = p.Id,
					Nome = p.Nome,
					DataDeNascimento = p.DataDeNascimento,
					CPF = p.CPF,
					Telefone = p.Telefone,
					Endereco = p.Endereco,
					Sexo = p.Sexo,
					TipoSanguineo = p.TipoSanguineo,
					Medico = new GetMedicoDTO
					{
						Nome = p.Medico.Nome,
						CRM = p.Medico.CRM,
						Especialidade = p.Medico.Especialidade,
					}
				}).FirstOrDefaultAsync(p => p.Id == pacienteId);
			if (paciente == null) return null;
            paciente.Endereco = request;
            await _context.SaveChangesAsync();
            return paciente;
		}

        public async Task<PacienteDTO> UpdatePacienteAsync(int pacienteId, PacienteDTO request)
        {
			var paciente = await _context.Pacientes
				.Include(p => p.Medico)
				.Select(p => new PacienteDTO
				{
					Id = p.Id,
					Nome = p.Nome,
					DataDeNascimento = p.DataDeNascimento,
					CPF = p.CPF,
					Telefone = p.Telefone,
					Endereco = p.Endereco,
					Sexo = p.Sexo,
					TipoSanguineo = p.TipoSanguineo,
					Medico = new GetMedicoDTO
					{
						Nome = p.Medico.Nome,
						CRM = p.Medico.CRM,
						Especialidade = p.Medico.Especialidade,
					}
				}).FirstOrDefaultAsync(p => p.Id == pacienteId);
			if (paciente == null) return null;

			paciente.Nome = request.Nome;
			paciente.DataDeNascimento = request.DataDeNascimento;
			paciente.CPF = request.CPF;
			paciente.Telefone = request.Telefone;
			paciente.Endereco = request.Endereco;
			paciente.Sexo = request.Sexo;
			paciente.TipoSanguineo = request.TipoSanguineo;
			paciente.Medico = request.Medico;

			await _context.SaveChangesAsync();

			return paciente;
		}
    }
}
