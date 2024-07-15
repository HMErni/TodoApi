using AutoMapper;
using TodoApi2.DTOs;
using TodoApi2.Models;

namespace TodoApi2.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoReadDto>();
            CreateMap<TodoCreateDto, Todo>();
            CreateMap<TodoUpdateDto, Todo>();
            CreateMap<Todo, TodoUpdateDto>();
        }
    }
}