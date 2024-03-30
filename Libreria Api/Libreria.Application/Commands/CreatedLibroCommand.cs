

namespace Libreria.Application.Commands
{
    public class CreatedLibroCommand : IRequest<IActionResult>
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Portada { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid? ListaId { get; set; } = null;
    }
}
