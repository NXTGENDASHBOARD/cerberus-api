using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cerberus.Dashboard.Api.Filters
{
    public class CustomSwaggerDocumentAttribute : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info = new OpenApiInfo
            {
                Title = "ITS 5.0 Student Selection Api",
                Version = "v1.0.0",
                Description = ".Net Core C# Api that is the middleware between external services and our Front-end UI",
                Contact = new OpenApiContact
                {
                    Name = "Freedom Khanyile | Development Engineer",
                    Email = "freedom.khanyile@adaptit.com"
                }
            };
        }
    }
}
