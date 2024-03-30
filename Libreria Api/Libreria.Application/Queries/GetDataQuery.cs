

using System.Linq.Expressions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Application.Queries
{
    public class GetDataQuery<TEntidad> : IRequest<List<TEntidad>> where TEntidad : class
    {
        public Func<TEntidad, bool>? condicion = null;

        public GetDataQuery(Func<TEntidad, bool>? condicion)
        {
            this.condicion = condicion;
        }
        
        public GetDataQuery()
        {
            
        }
        
    }
}



