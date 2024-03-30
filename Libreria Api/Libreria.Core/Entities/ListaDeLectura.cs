

namespace Libreria.Core.Entities
{
    public class ListaDeLectura : BaseEntity
    {
        public ListaDeLectura()
        {
            Libros = new HashSet<Libro>();
        }
        public string Nombre { get; set; }

        // Relación con Usuario
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        // Relación con Libro
        public virtual ICollection<Libro> Libros { get; set; }
    }

}
