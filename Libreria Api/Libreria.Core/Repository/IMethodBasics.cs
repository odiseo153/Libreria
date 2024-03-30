

using Microsoft.AspNetCore.Mvc;

namespace Libreria.Core.Repository
{
    public interface IMethodBasics
    {
        public IActionResult Get<T>();
        public T Create<T>(T entity);
        public T Update<T>(T entity);
        public T Delete<T>(Guid id);
    }
}



