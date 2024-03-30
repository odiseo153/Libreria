using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Api.Controllers;

public class Tools
{
    public static string DelvolverObjeto(Object entidad)
    {
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        var jsonString = JsonSerializer.Serialize(entidad, options);
           
        var contenido= new ContentResult
        {
            Content = jsonString,
            ContentType = "application/json",
        };

        return contenido.Content;
    }
}