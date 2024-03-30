using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using Libreria.Application.Commands;
using Libreria.Application.Queries;
using Libreria.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Libreria.Api.Controllers
{
    [SwaggerTag("Libros")]
    public class LibrosController : Controller
    {
        public IMediator mediador;

        public LibrosController(IMediator mediador) 
        {
            this.mediador = mediador;        
        }

        
        [HttpGet("Libro")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<Libro>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            summary:"Obtiene todos los libros ",
            Description = "Obtiene todos los libros que estan almacenados"
        )]
        public async Task<string> GetLibros()
        {
            return Tools.DelvolverObjeto(await mediador.Send(new GetDataQuery<Libro>()));
        }

        [SwaggerOperation(
            summary:"Obtiene un libro por un Id ",
            Description = "Obtiene un libro en base al id que le demos"
        )]
        [HttpGet("Libro/{id}")]
        [ProducesResponseType(typeof(Libro), StatusCodes.Status200OK)]
        public async Task<string> GetLibro(Guid Id)
        {
            return Tools.DelvolverObjeto(await mediador.Send(new GetDataByIdQuery<Libro>(Id)));
        }
        
        
        [HttpPost("Libro")]
        [ProducesResponseType(typeof(Libro), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateLibros([FromBody]CreatedLibroCommand libro)
        {
            return await mediador.Send(libro);
        }

        [HttpDelete("Libro/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<bool> DeleteLibros(Guid id)
        {
            return await mediador.Send(new DeleteEntityCommand<Libro>(id));
        }

        [HttpPut("Libro")]
        [ProducesResponseType(typeof(Libro), StatusCodes.Status200OK)]
        public async Task<Libro> UpdateLibro([FromBody]UpdateLibroCommand libro)
        {
            return await mediador.Send(libro);
        }
    }
}
