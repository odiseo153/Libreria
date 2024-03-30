namespace Libreria.Application.Commands;


public class CreatedListaCommand : IRequest<ListaDeLectura>
{
    public string Nombre { get; set; }
    
    
    public Guid UsuarioId { get; set; }
}





