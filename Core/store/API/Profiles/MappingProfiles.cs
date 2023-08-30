using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Dtos;
using AutoMapper;
using Core.Entities;
//vamos a indicar como se va a comportar los  ___ vs los dtos
namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais,PaisDto>().ReverseMap();
            CreateMap<Estado,EstadoDto>().ReverseMap();
        }
    }
}