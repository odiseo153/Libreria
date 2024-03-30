

namespace Libreria.Application.Handlers
{
    public class GetDataHandler<TEntidad> : IRequestHandler<GetDataQuery<TEntidad>, List<TEntidad>> where TEntidad : BaseEntity
    {
        private Repository<TEntidad> context;
        public GetDataHandler(Repository<TEntidad> libreriaContext) 
        {
            this.context = libreriaContext;        
        }


        public async Task<List<TEntidad>> Handle(GetDataQuery<TEntidad> request, CancellationToken cancellationToken)
        {
           
            return await context.Get(request.condicion);
        }
    }
}
