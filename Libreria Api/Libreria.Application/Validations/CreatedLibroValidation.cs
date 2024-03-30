

namespace Libreria.Application.Validations;

public class CreatedLibroValidation :AbstractValidator<CreatedLibroCommand>
{
    public CreatedLibroValidation()
    {
        RuleFor(x => x.Autor)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4);
        
        RuleFor(x => x.Descripcion)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4);
        
        RuleFor(x => x.Genero)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4);


    }
}