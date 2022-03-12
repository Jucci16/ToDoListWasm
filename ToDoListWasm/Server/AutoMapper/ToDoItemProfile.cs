using AutoMapper;
using ToDoListWasm.Dto;
using ToDoListWasm.Model;

namespace ToDoListWasm.Server.AutoMapper
{
    public class ToDoItemProfile : Profile
    {
        public ToDoItemProfile()
        {
            CreateMap<ToDoItemModel, ToDoItemDto>().ReverseMap();
            CreateMap<ToDoCollectionModel, ToDoCollectionDto>().ReverseMap();
        }
    }
}
