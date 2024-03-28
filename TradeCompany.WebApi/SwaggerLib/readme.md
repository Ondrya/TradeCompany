Добавить в Program.cs следующие команды для работы с версионированием

```csharp
app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        
        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
```

```csharp
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    // Add a custom operation filter which sets default values
    options.OperationFilter<SwaggerDefaultValues>();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
```

## Использумые материалы 
- [API versioning and Swagger in ASP.NET Core 7.0](https://mohsen.es/api-versioning-and-swagger-in-asp-net-core-7-0-fe45f67d8419)