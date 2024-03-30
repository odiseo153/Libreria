using Libreria.Application.Commands;
using Libreria.Application.Queries;
using Libreria.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Api.Controllers;

public class ListaController : Controller
{
    public IMediator mediador;

    public ListaController(IMediator mediador) 
    {
        this.mediador = mediador;        
    }

    [HttpGet("Listas")]
    public async Task<string> Listas(Guid usuarioId)
    {
       return Tools.DelvolverObjeto(await mediador.Send(new GetDataQuery<ListaDeLectura>()));
    }
    
    [HttpGet("Lista/{Id}")]
    public async Task<string> ListaById(Guid Id)
    {
        var response = await mediador.Send(new GetDataByIdQuery<ListaDeLectura>(Id));
        return Tools.DelvolverObjeto(response);
    }
    
    [HttpPost("Lista")]
    public async Task<ListaDeLectura> CrearLista([FromBody]CreatedListaCommand lista)
    {
        return await mediador.Send(lista);
    }
    
    [HttpPost("LibroLista")]
    [ProducesResponseType(typeof(Libro), StatusCodes.Status200OK)]
    public async Task<bool> GetLibroLista([FromBody]CreatedLibroAListaCommand relacion)
    {
        return await mediador.Send(relacion);
    }
    
    [HttpPut("Lista")]
    [ProducesResponseType(typeof(Libro), StatusCodes.Status200OK)]
    public async Task<ListaDeLectura> UpdateLista([FromBody]UpdateListaCommand lista)
    {
        return await mediador.Send(lista);
    }
    
    [HttpDelete("Lista/{id}")]
    public async Task<bool> EliminarLista(Guid id)
    {
        Console.WriteLine(id);
     return await mediador.Send(new DeleteEntityCommand<ListaDeLectura>(id));
    }
    
}