
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Services.Interfaces
{
    public interface IAlunoService : IGenericService<Aluno>
    {
        Task<IEnumerable<Aluno>> GetAll(bool includeDisciplina = false);
        Task<Aluno> GetAlunoById(int id, bool includeDisciplina = false);
        Task<IEnumerable<Aluno>> GetAlunoByDisciplina(int disciplinaId);
    }
}
