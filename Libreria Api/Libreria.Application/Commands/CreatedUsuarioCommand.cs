

namespace Libreria.Application.Commands
{
    public class CreatedUsuarioCommand : IRequest<IActionResult>
    {
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
    }
}
