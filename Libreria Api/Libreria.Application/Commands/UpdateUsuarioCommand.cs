

namespace Libreria.Application.Commands
{
    public class UpdateUsuarioCommand : BaseEntity,IRequest<Usuario> 
    {
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
    }
}

