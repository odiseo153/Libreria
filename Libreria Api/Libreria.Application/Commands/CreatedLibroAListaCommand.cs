namespace Libreria.Application.Commands;

public class CreatedLibroAListaCommand : IRequest<bool>
{
    public Guid idLibro { get; set; }
    public Guid idLista { get; set; }
}