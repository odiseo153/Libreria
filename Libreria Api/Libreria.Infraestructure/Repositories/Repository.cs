using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Libreria.Core.Entities;
using Libreria.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using System.Diagnostics;


namespace Libreria.Infraestructure.Repositories
{
    public class Repository<T> where T : class
    {
        private LibreriaContext context;

        public Repository(LibreriaContext libreriaContext)
        {
            this.context = libreriaContext;
        }


        public async Task<T> Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> LibroALista(Guid idLibro, Guid idLista, bool sacar = false)
        {
            try
            {
                var lista = await context.ListaDeLectura.SingleOrDefaultAsync(x => x.Id ==idLista);
                var libro = await context.Libros.SingleOrDefaultAsync(x=>x.Id == idLibro);

                if (!sacar)
                {
                    lista.Libros.Add(libro);
                }
                else
                {
                    lista.Libros.Remove(libro);
                }

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Hubo un error: "+e);
                return false;
            }
        }


        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var entidad = await context.Set<T>().FindAsync(id);
                context.Remove(entidad);

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<T>> Get(Func<T, bool> condicion = null)
        {
            var entidad = typeof(T);


            if (entidad == new Usuario().GetType())
            {
                
                var user = context.Usuarios
                    .Include(x => x.Libros)
                    .Include(x => x.ListaDeLecturas)
                    .ToList();

                //if (condicion != null) response.Where(condicion as Func<Usuario,bool>);

                return user as List<T>;
            }


            if (entidad == new Libro().GetType())
            {
                var response = context.Libros
                    .Include(x => x.Usuarios)
                    .Include(x => x.ListaDeLecturas);

                if (condicion != null) response.Where(condicion as Func<Libro, bool>);

                return response.ToList() as List<T>;
            }


            if (entidad == new ListaDeLectura().GetType())
            {
                var response = context.ListaDeLectura
                    .Include(x => x.Libros)
                    .Include(x => x.Usuario);

                if (condicion != null) response.Where(condicion as Func<ListaDeLectura, bool>);

                return response.ToList() as List<T>;
            }

            throw new Exception("Esa entidad no esta registrada");
        }


        public async Task<T> Get(Guid id)
        {
            var entidad =  typeof(T);
            
            if (entidad == new Usuario().GetType())
            {
                
                var user = context.Usuarios
                    .Include(x => x.Libros)
                    .Include(x => x.ListaDeLecturas)
                    .FirstOrDefault(x => x.Id == id);

                //if (condicion != null) response.Where(condicion as Func<Usuario,bool>);

                return user as T;
            }


            if (entidad == new Libro().GetType())
            {
                var response = context.Libros
                    .Include(x => x.Usuarios)
                    .Include(x => x.ListaDeLecturas)
                    .FirstOrDefault(x => x.Id == id);;

                //if (condicion != null) respon se.Where(condicion as Func<Libro, bool>);

                return response as T;
            }


            if (entidad == new ListaDeLectura().GetType())
            {
                var response = context.ListaDeLectura
                    .Include(x => x.Libros)
                    .Include(x => x.Usuario)
                    .FirstOrDefault(x => x.Id == id);;

                //if (condicion != null) response.Where(condicion as Func<ListaDeLectura, bool>);

                return response as T;
            }


            return await context.Set<T>().FindAsync(id);
        }

        public T Update(T entity)
        {
            var tipoDeEntidad = entity.GetType();

            if (tipoDeEntidad == new Libro().GetType())
            {
                var entidadNueva = entity as Libro;
                
                Actualizar(entidadNueva);
            }
            else if (tipoDeEntidad == new ListaDeLectura().GetType())
            {
                var entidadNueva = entity as ListaDeLectura;
                
                Actualizar(entidadNueva);
            }
            else if (tipoDeEntidad == new Usuario().GetType())
            {
                var entidadNueva = entity as Usuario;

                Actualizar(entidadNueva);
            }


            return entity;
        }

        public void Actualizar(BaseEntity entidad)
        {
            var entidadDb = context.Set<T>().Find(entidad.Id);

            foreach (var propiedad in entidad.GetType().GetProperties())
            {
                var valorEntidad = propiedad.GetValue(entidad);
                var valorFinal = valorEntidad ?? propiedad.GetValue(entidadDb);

                propiedad.SetValue(entidadDb, valorFinal);
            }

            context.SaveChanges();
        }
    }
}