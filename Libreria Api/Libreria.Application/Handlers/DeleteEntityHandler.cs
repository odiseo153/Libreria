

namespace Libreria.Application.Handlers
{
    public class DeleteEntityHandler<TEntidad> : IRequestHandler<DeleteEntityCommand<TEntidad>, bool> where TEntidad : BaseEntity
    {
        private Repository<TEntidad> context;
        public DeleteEntityHandler(Repository<TEntidad> libreriaContext)
        {
            this.context = libreriaContext;
        }
        public async Task<bool> Handle(DeleteEntityCommand<TEntidad> request, CancellationToken cancellationToken)
        {
            return await context.Delete(request.Id);
        }
    }
}
