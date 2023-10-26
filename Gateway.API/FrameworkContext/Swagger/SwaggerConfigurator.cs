namespace Gateway.API.FrameworkContext.Swagger;

/// <summary>
/// Provides swagger related configuration
/// </summary>
public static class SwaggerConfigurator
{
    /// <summary>
    /// Add and customize swagger gen
    /// </summary>
    /// <param name="services"><inheritdoc cref="IServiceCollection" path="/summary/node()"/></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomizedSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        
        services.ConfigureOptions<SwaggerGenOptionsConfigurator>();
        services.ConfigureOptions<SwaggerUIOptionsConfigurator>();
        
        return services;
    }

    /// <summary>
    /// Add and customize swagger pipeline
    /// </summary>
    /// <param name="app"><inheritdoc cref="IApplicationBuilder" path="/summary/node()"/></param>
    /// <returns></returns>
    public static IApplicationBuilder UseCustomizedSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}