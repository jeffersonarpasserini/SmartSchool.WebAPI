using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;
using SQLitePCL;

namespace SmartSchool.WebAPI.Data;

public class AlunoRepository : GenericRepository<Aluno>, IAlunoRepository
{
    private readonly AppDbContext _context;
    
    public AlunoRepository(AppDbContext context) : base(context)
    {
        this._context = context;
    }

    public Aluno[] GetAll(bool includeDisciplina)
    {
        IQueryable<Aluno> query = _context.Alunos;
        if (includeDisciplina)
        {
            query = query.Include(a => a.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
        }

        query = query.AsNoTracking().OrderBy(a => a.Id);

        return query.ToArray();
    }

    public Aluno GetAlunoById(int alunoId, bool includeDisciplina=false)
    {
        IQueryable<Aluno> query = _context.Alunos;
        if (includeDisciplina)
        {
            query = query.Include(a => a.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
        }

        query = query.AsNoTracking()
            .Where(aluno => aluno.Id == alunoId)
            .OrderBy(a => a.Id);
       

        return query.FirstOrDefault();
    }

    public Aluno[] GetAlunoByDisciplina(int disciplinaId)
    {
        IQueryable<Aluno> query = _context.Alunos;
        
        query = query.Include(a => a.AlunosDisciplinas)
            .ThenInclude(ad => ad.Disciplina)
            .AsNoTracking()
            .Where(aluno => aluno.AlunosDisciplinas
                .Any(ad => ad.DisciplinaId == disciplinaId));
       /* 
        query = query.Include(a => a.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor)
                .AsNoTracking()
                .Where(aluno => aluno.AlunosDisciplinas.Any(ad =>ad.DisciplinaId == disciplinaId));
        */
        return query.ToArray();
    }
}