using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Gateway.API.FrameworkContext.Swagger;

/// <summary>
/// <see cref="IConfigureOptions{TOptions}"/> implementations for <see cref="SwaggerUIOptions"/>
/// </summary>
public class SwaggerUIOptionsConfigurator : IConfigureOptions<SwaggerUIOptions>
{
    #region Fields

    /// <summary>
    /// <inheritdoc cref="IApiVersionDescriptionProvider"/>
    /// </summary>
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    #endregion

    #region Constructors

    /// <summary>
    /// Create a new instance of <see cref="SwaggerUIOptionsConfigurator"/>
    /// </summary>
    /// <param name="apiVersionDescriptionProvider"><inheritdoc cref="_apiVersionDescriptionProvider" path="/summary/node()"/></param>
    public SwaggerUIOptionsConfigurator(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    {
        _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
    }

    #endregion
    
    #region Methods

    /// <inheritdoc/>
    public void Configure(SwaggerUIOptions options)
    {
        foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    }

    #endregion
}