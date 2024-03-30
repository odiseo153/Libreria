

using Libreria.Application.Validations;

namespace Libreria.Application.Handlers
{
    public class CreatedLibroHandler : IRequestHandler<CreatedLibroCommand, IActionResult>
    {
        private Repository<Libro> context;
        public CreatedLibroHandler(Repository<Libro> libreriaContext)
        {
            this.context = libreriaContext;
        }

        public async Task<IActionResult> Handle(CreatedLibroCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreatedLibroValidation().Validate(request);
            
            if(!validation.IsValid)
            {
                return new JsonResult(validation.Errors);
            }
            
            var entidad = ProductMapper.mapper.Map<Libro>(request);


           return new JsonResult(await context.Create(entidad));
        }
    }
}
