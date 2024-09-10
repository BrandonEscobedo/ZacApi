using Application.DTO.Request.Pacientes;
using Application.DTO.Request.Padecimientos;
using Application.DTO.Request.Recetas;
using AutoMapper;
using Domain.DbModels;
using Domain.DbModels.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utility
{
    public class AutoMapperApplicationProfile : Profile
    {
        public AutoMapperApplicationProfile()
        {
            CreateMap<PacienteRequest, Paciente>()
                .ForMember(x => x.Personales, x => x.MapFrom(src => src.PersonalesRequest))
                .ForMember(x => x.Contacto, x => x.MapFrom(src => src.PacienteContactoRequest))
                .ForMember(x => x.SintomasAntecedentes, x => x.MapFrom(src => src.SintomasRequest))
                .ForMember(x => x.PacientePadecimientos, d => d.Ignore()).ReverseMap();

            CreateMap<PacientePersonales, PacientePersonalesRequest>()
                .ForMember(x => x.Genero, src => src.Ignore()).ReverseMap();
            CreateMap<PacienteContacto, PacienteContactoRequest>().ReverseMap();
            CreateMap<PacienteSintomasAntecedentes, PacienteSintomasAntecedentesRequest>().ReverseMap();
            CreateMap<Padecimiento, PadecimientoRequest>().ReverseMap();
            CreateMap<IngredienteRequest, Ingrediente>().ForMember(dest=>dest.TipoIngrediente , x=>x.MapFrom(s=>s.TipoIngredienteEnum)).ReverseMap();
            CreateMap<Receta, RecetaRequest>().ReverseMap();

        }
    }
}
