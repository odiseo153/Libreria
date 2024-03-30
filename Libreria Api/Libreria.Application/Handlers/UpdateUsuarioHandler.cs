

namespace Libreria.Application.Handlers
{
    public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, Usuario>
    {
        private Repository<Usuario> context;
        
        public UpdateUsuarioHandler(Repository<Usuario> libreriaContext)
        {
            this.context = libreriaContext;
        }

        public async Task<Usuario> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = ProductMapper.mapper.Map<Usuario>(request);
            var response = context.Update(usuario);

            return response;
        }
    }
}
