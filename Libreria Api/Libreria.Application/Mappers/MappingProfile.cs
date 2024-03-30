
using AutoMapper;
using Libreria.Application.Commands;


namespace Catalog.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreatedLibroCommand, Libro>().ReverseMap();
            CreateMap<CreatedUsuarioCommand, Usuario>().ReverseMap();
            
            CreateMap<UpdateUsuarioCommand, Usuario>().ReverseMap();
            CreateMap<UpdateListaCommand, ListaDeLectura>().ReverseMap();
            CreateMap<UpdateLibroCommand, Libro>().ReverseMap();
            
            CreateMap<CreatedListaCommand, ListaDeLectura>().ReverseMap();





        }
    }
}
