

using Libreria.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Infraestructure.Repositories
{
    public class UsuarioRepository : IMethodBasics
    {
        public T Create<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Get<T>()
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}



