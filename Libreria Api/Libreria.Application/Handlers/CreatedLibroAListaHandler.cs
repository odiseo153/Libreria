namespace Libreria.Application.Handlers;

public class CreatedLibroAListaHandler : IRequestHandler<CreatedLibroAListaCommand,bool>
{
    private Repository<ListaDeLectura> context;
    
    public CreatedLibroAListaHandler(Repository<ListaDeLectura> libreriaContext)
    {
        this.context = libreriaContext;
    }

    public async Task<bool> Handle(CreatedLibroAListaCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine(request.idLibro+"  :  "+request.idLista);
        return await context.LibroALista(request.idLibro,request.idLista);
    }
}