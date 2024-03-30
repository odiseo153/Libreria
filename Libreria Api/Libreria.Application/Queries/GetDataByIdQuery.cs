using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Queries
{
    public class GetDataByIdQuery<TEntidad> : IRequest<TEntidad> where TEntidad : class
    {
        public Guid Id { get; set; }

        public GetDataByIdQuery(Guid id) 
        {
        this.Id = id;
        }
    }
}
