using AutoMapper;
using TodoList.Data.Dtos;
using TodoList.Models;

namespace TodoList.Profiles
{
    public class TarefasProfile : Profile
    {
        public TarefasProfile()
        {
            CreateMap<CreateTarefasDto, Tarefas>();
            CreateMap<Tarefas, ReadTarefasDto>();
            CreateMap<UpdateTarefasDto, Tarefas>();
            CreateMap<Tarefas, UpdateTarefasDto>();
        }
    }
}
