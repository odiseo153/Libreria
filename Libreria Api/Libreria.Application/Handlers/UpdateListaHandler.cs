namespace Libreria.Application.Handlers;

public class UpdateListaHandler : IRequestHandler<UpdateListaCommand,ListaDeLectura>
{
    private Repository<ListaDeLectura> context;
    
    public UpdateListaHandler(Repository<ListaDeLectura> libreriaContext)
    {
        this.context = libreriaContext;
    }
    
    public async Task<ListaDeLectura> Handle(UpdateListaCommand request, CancellationToken cancellationToken)
    {
        var lista = ProductMapper.mapper.Map<ListaDeLectura>(request);
        var response = ProductMapper.mapper.Map<ListaDeLectura>(request);

        return response;
    }
}