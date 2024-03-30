
namespace Libreria.Application.Validations;

public class CreatedUsuarioValidations : AbstractValidator<CreatedUsuarioCommand>
{
   public CreatedUsuarioValidations()
   {
      RuleFor(x => x.Nombre)
         .NotEmpty()
         .NotNull();
      
      RuleFor(x => x.ImagenUrl)
         .NotEmpty()
         .NotNull();

   }
}
