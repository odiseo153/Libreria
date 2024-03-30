

using System.Web.Helpers;
using Libreria.Application.Validations;

namespace Libreria.Application.Handlers
{
    public class CreatedUsuarioHandler : IRequestHandler<CreatedUsuarioCommand, IActionResult>
    {
        private Repository<Usuario> context;
        public CreatedUsuarioHandler(Repository<Usuario> libreriaContext)
        {
            this.context = libreriaContext;
        }

        public async Task<IActionResult> Handle(CreatedUsuarioCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreatedUsuarioValidations().Validate(request);
            var usuario = ProductMapper.mapper.Map<Usuario>(request);

            if (!validation.IsValid)
            {
                return new JsonResult(validation.Errors);
            }

            return new JsonResult(await context.Create(usuario));           
        }
    }
}
