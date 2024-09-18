using AutoMapper;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Services.Interfaces;

namespace SmartSchool.WebAPI.Services.Entities
{
    public class AlunoService : GenericService<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
            : base(alunoRepository, mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Aluno>> GetAll(bool includeDisciplina = false)
        {
            var alunos = _alunoRepository.GetAll(includeDisciplina);
            return _mapper.Map<IEnumerable<Aluno>>(alunos);
        }

        public async Task<Aluno> GetAlunoById(int id, bool includeDisciplina = false)
        {
            var aluno = _alunoRepository.GetAlunoById(id, includeDisciplina);
            if (aluno == null)
            {
                throw new KeyNotFoundException($"Aluno com id: {id} não encontrado.");
            }
            return _mapper.Map<Aluno>(aluno);
        }

        public async Task<IEnumerable<Aluno>> GetAlunoByDisciplina(int disciplinaId)
        {
            var alunos = _alunoRepository.GetAlunoByDisciplina(disciplinaId);
            return _mapper.Map<IEnumerable<Aluno>>(alunos);
        }
    }
}