using System.Text.Json;
using System.Text.Json.Serialization;
using Libreria.Application.Commands;
using Libreria.Application.Queries;
using Libreria.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Api.Controllers
{
    public class UsuarioController : Controller
    {
        public IMediator mediador;
        

        public UsuarioController(IMediator mediador)
        {
            this.mediador = mediador;
        }
        
        
        [HttpGet("Usuario")]
        [ProducesResponseType(typeof(Task<List<Usuario>>), StatusCodes.Status200OK)]
        public async Task<string> GetUsuarios()
        {
            //var include = new GetDataQuery<Libro>().include = u=> u;
            var response = await mediador.Send(new GetDataQuery<Usuario>());
            
           return Tools.DelvolverObjeto(response);
        }

        [HttpDelete("Usuario/{id}")]
        [ProducesResponseType(typeof(Task<bool>), StatusCodes.Status200OK)]
        public async Task<bool> DeleteUsuario(Guid id)
        {
            
            return await mediador.Send(new DeleteEntityCommand<Usuario>(id));
        }

        [HttpGet("Usuario/{id}")]
        [ProducesResponseType(typeof(Task<Usuario>), StatusCodes.Status200OK)]
        public async Task<string> GetUsuarioById(Guid id)
        {
            //var response = await mediador.Send(new GetDataByIdQuery<Usuario>(id));
            
            return Tools.DelvolverObjeto(await mediador.Send(new GetDataByIdQuery<Usuario>(id)));
        }

        [HttpPost("Usuario")]
        [ProducesResponseType(typeof(Task<Usuario>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUsuario([FromBody]CreatedUsuarioCommand usuario)
        {
            return await mediador.Send(usuario);
        }

        [HttpPut("Usuario")]
        [ProducesResponseType(typeof(Task<Usuario>), StatusCodes.Status200OK)]
        public async Task<Usuario> UpdateUsuario([FromBody]UpdateUsuarioCommand usuario)
        {
            return await mediador.Send(usuario);
        }





    }
}
