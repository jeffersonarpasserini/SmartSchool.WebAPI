using AutoMapper;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Objects.Dtos.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AlunoDto, Aluno>().ReverseMap();
        CreateMap<Aluno, AlunoDto>().ForMember(
            dest =>dest.Nome,
            opt =>opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"));
    }
}