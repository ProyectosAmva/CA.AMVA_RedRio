using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Linq;
using System;
public class FileUploadOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.ActionDescriptor.Parameters
            .Any(p => p.ParameterType == typeof(IFormFile)))
        {
            operation.RequestBody = new OpenApiRequestBody
            {
                Content = { /* misma configuración de arriba */ }
            };
        }
    }
}

public class IgnoreFormFileFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(IFormFile))
        {
            schema.Type = "string";
            schema.Format = "binary";
            schema.Description = "File upload (use Postman for testing)";
        }
    }
}

namespace AMVA.REDRIO.Filters
{
    /// <summary>
    /// Atributo para marcar endpoints que manejan upload de archivos
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerUploadAttribute : Attribute
    {
    }
}