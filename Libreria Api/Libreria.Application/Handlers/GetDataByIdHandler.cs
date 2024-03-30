

namespace Libreria.Application.Handlers
{
    public class GetDataByIdHandler<TEntidad> : IRequestHandler<GetDataByIdQuery<TEntidad>, TEntidad> where TEntidad : class
    {
        private Repository<TEntidad> context;
        public GetDataByIdHandler(Repository<TEntidad> libreriaContext)
        {
            this.context = libreriaContext;
        }

        public async Task<TEntidad> Handle(GetDataByIdQuery<TEntidad> request, CancellationToken cancellationToken)
        {
            return await context.Get(request.Id);
        }
    }
}
