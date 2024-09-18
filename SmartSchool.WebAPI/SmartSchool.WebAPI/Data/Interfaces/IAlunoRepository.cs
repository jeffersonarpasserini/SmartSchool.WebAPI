﻿using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data;

public interface IAlunoRepository : IRepository
{
    Aluno[] GetAll(bool includeDisciplina);
    Aluno GetAlunoById(int alunoId, bool includeDisciplina=false);
    Aluno[] GetAlunoByDisciplina(int disciplinaId);
    
}