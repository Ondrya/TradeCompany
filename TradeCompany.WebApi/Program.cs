using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TradeCompanyApp.Domain.Interfaces;
using TradeCompanyApp.RepositoryEF;

namespace TradeCompany.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var cn = builder.Configuration.GetConnectionString("TradeCompanyAppContext");
            builder.Services.AddSingleton<IDataService>(new DataService(cn));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            builder.Services.AddSwaggerGen(
                c =>
            {
                c.IncludeXmlComments(
                    Path.Combine(
                        AppContext.BaseDirectory,
                        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"
                        )
                    );
            }
            );

            var app = builder.Build();

            app.UseDeveloperExceptionPage();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(
                    options =>
                    {
                        foreach (var description in app.DescribeApiVersions())
                        {
                            var url = $"/swagger/{description.GroupName}/swagger.json";
                            var name = description.GroupName.ToUpperInvariant();
                            options.SwaggerEndpoint(url, name);
                        }
                    }
                    );
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
