
namespace Libreria.Application.Commands
{
    public class DeleteEntityCommand<TEntidad>: BaseEntity,IRequest<bool>
    {
        public DeleteEntityCommand(Guid id)
        {
            Id = id;
        }
    }
}
