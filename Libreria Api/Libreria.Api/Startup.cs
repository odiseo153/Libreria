//using Microsoft.EntityFrameworkCore;

using Libreria.Application.Commands;
using Libreria.Application.Handlers;
using Libreria.Application.Queries;
using Libreria.Core.Entities;
using Libreria.Infraestructure.Context;
using Libreria.Infraestructure.Repositories;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace Libreria.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi Api de Libreria", Version = "v1" });
                c.EnableAnnotations();
            });


            services.AddDbContext<LibreriaContext>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<Repository<Libro>>();
            services.AddScoped<Repository<Usuario>>();
            services.AddScoped<Repository<ListaDeLectura>>();

  
            services.AddScoped<IRequestHandler<GetDataByIdQuery<Libro>, Libro>, GetDataByIdHandler<Libro>>();
            services.AddScoped<IRequestHandler<GetDataByIdQuery<Usuario>, Usuario>, GetDataByIdHandler<Usuario>>();
            services.AddScoped<IRequestHandler<GetDataByIdQuery<ListaDeLectura>, ListaDeLectura>, GetDataByIdHandler<ListaDeLectura>>();

            services.AddScoped<IRequestHandler<GetDataQuery<Usuario>, List<Usuario>>, GetDataHandler<Usuario>>();
            services.AddScoped<IRequestHandler<GetDataQuery<ListaDeLectura>, List<ListaDeLectura>>, GetDataHandler<ListaDeLectura>>();
            services.AddScoped<IRequestHandler<GetDataQuery<Libro>, List<Libro>>, GetDataHandler<Libro>>(); 
            
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Usuario>, bool>, DeleteEntityHandler<Usuario>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Libro>, bool>, DeleteEntityHandler<Libro>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<ListaDeLectura>, bool>, DeleteEntityHandler<ListaDeLectura>>();
            
            services.AddScoped<IRequestHandler<CreatedLibroCommand, IActionResult>,CreatedLibroHandler>();
            services.AddScoped<IRequestHandler<CreatedUsuarioCommand, IActionResult>, CreatedUsuarioHandler>();
            services.AddScoped<IRequestHandler<CreatedListaCommand, ListaDeLectura>, CreatedListaHandler>();
            services.AddScoped<IRequestHandler<CreatedLibroAListaCommand, bool>, CreatedLibroAListaHandler>();
            
            services.AddScoped<IRequestHandler<UpdateLibroCommand, Libro>, UpdateLibroHandler>();
            services.AddScoped<IRequestHandler<UpdateUsuarioCommand, Usuario>, UpdateUsuarioHandler>();
            services.AddScoped<IRequestHandler<UpdateListaCommand, ListaDeLectura>, UpdateListaHandler>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using(var db = new LibreriaContext())
            {
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
            });

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }

    }
}
