using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SendSMSSayyehBan.Config;

/// <summary>
/// افزونه swagger
/// </summary>
public static class SwaggerExtension
{
    /// <summary>
    /// اضافه کردن افزونه
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddOurSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // تعریف SwaggerDoc برای v1 و v2
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API v1",
                Version = "v1",
                Description = "Web API SayyehBan.ir - Version 1",
                Contact = new OpenApiContact
                {
                    Name = "سایه بان",
                    Url = new Uri("http://sayyehban.ir/")
                }
            });

            c.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "API v2",
                Version = "v2",
                Description = "Web API SayyehBan.ir - Version 2",
                Contact = new OpenApiContact
                {
                    Name = "سایه بان",
                    Url = new Uri("http://sayyehban.ir/")
                }
            });

            // اضافه کردن مستندات XML
            var xmlFile = Path.Combine(AppContext.BaseDirectory, "Docs.xml");
            var xmlExists = File.Exists(xmlFile);
            if (xmlExists)
            {
                c.IncludeXmlComments(xmlFile, true);
            }

            // تنظیمات امنیتی JWT
            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            c.AddSecurityDefinition("Bearer", securitySchema);

            var securityRequirement = new OpenApiSecurityRequirement();
            securityRequirement.Add(securitySchema, new[] { "Bearer" });
            c.AddSecurityRequirement(securityRequirement);

            // DocumentFilter برای حذف کامل api-version parameters
            c.DocumentFilter<RemoveVersionFromParameterFilter>();

            // OperationFilter برای اطمینان از حذف از operations
            c.OperationFilter<RemoveApiVersionParameterFilter>();
        });

        return services;
    }
}

/// <summary>
/// فیلتر برای حذف کامل پارامتر api-version از کل Swagger Document
/// </summary>
public class RemoveVersionFromParameterFilter : IDocumentFilter
{
    /// <summary>
    /// اعمال فیلتر روی Swagger Document
    /// </summary>
    /// <param name="swaggerDoc">Swagger Document</param>
    /// <param name="context">Document Filter Context</param>
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // حذف از Components.Parameters
        if (swaggerDoc.Components?.Parameters != null)
        {
            var apiVersionParam = swaggerDoc.Components.Parameters
                .Where(p => p.Key.Equals("api-version", StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var param in apiVersionParam)
            {
                swaggerDoc.Components.Parameters.Remove(param.Key);
            }
        }

        // حذف از PathItems
        if (swaggerDoc.Paths != null)
        {
            foreach (var pathItem in swaggerDoc.Paths.ToList())
            {
                RemoveVersionParametersFromPath(pathItem.Value);
            }
        }
    }

    /// <summary>
    /// حذف پارامترهای ورژن از PathItem
    /// </summary>
    /// <param name="pathItem">PathItem</param>
    private void RemoveVersionParametersFromPath(OpenApiPathItem pathItem)
    {
        // حذف از Parameters در PathItem
        if (pathItem.Parameters != null)
        {
            RemoveApiVersionParameters(pathItem.Parameters);
        }

        // حذف از Operations در PathItem
        foreach (var operation in pathItem.Operations)
        {
            RemoveVersionParametersFromOperation(operation.Value);
        }
    }

    /// <summary>
    /// حذف پارامترهای ورژن از Operation
    /// </summary>
    /// <param name="operation">Operation</param>
    private void RemoveVersionParametersFromOperation(OpenApiOperation operation)
    {
        if (operation.Parameters != null)
        {
            RemoveApiVersionParameters(operation.Parameters);
        }
    }

    /// <summary>
    /// حذف پارامترهای api-version از لیست پارامترها
    /// </summary>
    /// <param name="parameters">لیست پارامترها</param>
    private void RemoveApiVersionParameters(IList<OpenApiParameter> parameters)
    {
        var parametersToRemove = parameters
            .Where(p => p.Name != null && p.Name.Equals("api-version", StringComparison.OrdinalIgnoreCase))
            .ToList();

        foreach (var param in parametersToRemove)
        {
            parameters.Remove(param);
        }
    }
}

/// <summary>
/// فیلتر برای حذف پارامتر api-version از Operations (backup)
/// </summary>
public class RemoveApiVersionParameterFilter : IOperationFilter
{
    /// <summary>
    /// اعمال فیلتر روی Operation
    /// </summary>
    /// <param name="operation">OpenAPI Operation</param>
    /// <param name="context">Operation Filter Context</param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // حذف پارامتر api-version از query parameters
        if (operation.Parameters != null)
        {
            var parametersToRemove = operation.Parameters
                .Where(p => p.Name != null && p.Name.Equals("api-version", StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var param in parametersToRemove)
            {
                operation.Parameters.Remove(param);
            }
        }
    }
}