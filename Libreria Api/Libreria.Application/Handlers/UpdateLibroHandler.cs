

namespace Libreria.Application.Handlers
{
    public class UpdateLibroHandler : IRequestHandler<UpdateLibroCommand,Libro>
    {
        private Repository<Libro> repository;

        public UpdateLibroHandler(Repository<Libro> repository) 
        {
            this.repository = repository;        
        }

        public async Task<Libro> Handle(UpdateLibroCommand request, CancellationToken cancellationToken)
        {
            var libro = ProductMapper.mapper.Map<Libro>(request);
            var response = repository.Update(libro);

            return response;
        }
    }
}
