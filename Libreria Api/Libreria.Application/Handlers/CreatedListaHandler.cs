namespace Libreria.Application.Handlers;

public class CreatedListaHandler : IRequestHandler<CreatedListaCommand,ListaDeLectura>
{
    private Repository<ListaDeLectura> context;
    
    public CreatedListaHandler(Repository<ListaDeLectura> libreriaContext)
    {
        this.context = libreriaContext;
    }

    public async Task<ListaDeLectura> Handle(CreatedListaCommand request, CancellationToken cancellationToken)
    {
        var lista = ProductMapper.mapper.Map<ListaDeLectura>(request);
        
        return await context.Create(lista); 
    }
}