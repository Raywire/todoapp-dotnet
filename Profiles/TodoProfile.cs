using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todoapp_dotnet.Models;
using todoapp_dotnet.Models.DTOs.Requests;

namespace todoapp_dotnet.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoCreateDto, ItemData>();
        }
    }
}