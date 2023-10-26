using Asp.Versioning;
using Gateway.API.FrameworkContext.Swagger;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

#region Configuration

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

#endregion

#region Api versioning

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    options.ReportApiVersions = true;
}).AddApiExplorer(option =>
{
    option.SubstituteApiVersionInUrl = true;
    option.GroupNameFormat = "'v'VVV";
});

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomizedSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseCustomizedSwagger();

app.UseHttpsRedirection();
app.UseMetricServer();
app.UseAuthorization();

app.MapControllers();
app.UseHttpMetrics(options => { options.AddRouteParameter("version"); });

app.Run();