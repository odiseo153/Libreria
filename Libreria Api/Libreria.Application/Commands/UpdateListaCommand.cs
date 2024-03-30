public class UpdateListaCommand : IRequest<ListaDeLectura>
{
    public string Nombre { get; set; }
    
    public Guid ListaId { get; set; }
}