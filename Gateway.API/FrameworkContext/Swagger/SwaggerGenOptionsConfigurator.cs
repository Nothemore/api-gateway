using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Gateway.API.FrameworkContext.Swagger;

/// <summary>
/// <see cref="IConfigureOptions{TOptions}"/> implementations for <see cref="SwaggerGenOptions"/>
/// </summary>
public class SwaggerGenOptionsConfigurator : IConfigureOptions<SwaggerGenOptions>
{
    #region Fields

    /// <summary>
    /// <inheritdoc cref="IApiVersionDescriptionProvider"/>
    /// </summary>
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    #endregion

    #region Constructors

    /// <summary>
    /// Create a new instance of <see cref="SwaggerGenOptionsConfigurator"/>
    /// </summary>
    /// <param name="apiVersionDescriptionProvider"><inheritdoc cref="_apiVersionDescriptionProvider" path="/summary/node()"/></param>
    public SwaggerGenOptionsConfigurator(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    {
        _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var apiVersionDescription in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(apiVersionDescription.GroupName, new OpenApiInfo()
            {
                Version = apiVersionDescription.ApiVersion.ToString(),
                Title = $"Api gateway {apiVersionDescription.ApiVersion}",
            });
        }
    }

    #endregion
}