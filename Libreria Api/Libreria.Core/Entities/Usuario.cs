

namespace Libreria.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }

        // Relación con Libro
        public virtual ICollection<Libro> Libros { get; set; }

        // Relación con Lista de Lectura
        public virtual ICollection<ListaDeLectura> ListaDeLecturas { get; set; }
    }

}



