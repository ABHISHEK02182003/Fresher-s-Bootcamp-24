# Feature Flags in ASP.NET Core Web Applications

Feature flags, also known as feature toggles or feature switches, provide a powerful way to manage and control features in your ASP.NET Core web applications. By using feature flags, you can enable or disable certain features dynamically without modifying the codebase. This article will guide you through setting up feature flags in an ASP.NET Core web application using Microsoft Feature Management.

## Prerequisites

Before you start, ensure that you have the necessary tools and libraries installed:

- Visual Studio or Visual Studio Code
- .NET SDK
- Microsoft.FeatureManagement NuGet package

## Setting up Feature Management

First, install the `Microsoft.FeatureManagement` NuGet package. You can do this through the Package Manager Console:

```bash
dotnet add package Microsoft.FeatureManagement.AspNetCore
```

Or using the Visual Studio NuGet Package Manager.

Now, let's modify the `Program.cs` file to include the necessary configurations.

### Program.cs

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi.Models;

namespace FeatureFlags
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddFeatureManagement();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "feature_flags",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            app.MapControllers();

            if (builder.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.Run();
        }
    }
}
```

With this setup, the Feature Management service is registered in the dependency injection container.

## Using Feature Flags in Controllers

Now, let's see how to use feature flags in your controllers. In the `WeatherController.cs` file, we inject `IFeatureManager` into the constructor.

### WeatherController.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureManagementUsingControllers.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        public WeatherController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            var isRainEnabled = await _featureManager.IsEnabledAsync("FeatureRain");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                RainExpected = isRainEnabled ? $"{rng.Next(0, 100)}%" : null,
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();
        }

        [FeatureGate("AdvanceEnabled")]
        [HttpGet("advanced")]
        public async Task<IEnumerable<WeatherForecast>> GetAdvanced()
        {
            var useNewAlgorithm = await _featureManager.IsEnabledAsync("NewAlgorithmEnabled");

            return useNewAlgorithm
            ? await NewAlgorithm()
            : await OldAlgorithm();
        }

        private async Task<IEnumerable<WeatherForecast>> OldAlgorithm()
        {
            var rng = new Random();
            var isRainEnabled = await _featureManager.IsEnabledAsync("RainEnabled");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                RainExpected = isRainEnabled ? $"{rng.Next(0, 100)}% OLD" : null,
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }

        private async Task<IEnumerable<WeatherForecast>> NewAlgorithm()
        {
            var rng = new Random();
            var isRainEnabled = await _featureManager.IsEnabledAsync("RainEnabled");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                RainExpected = isRainEnabled ? $"{rng.Next(0, 100)}% NEW" : null,
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }
    }
}
```

## Generating Swagger Documentation

In the provided code, Swagger documentation is integrated to provide a clear view of your API. Swagger UI is available in the development environment. To generate the Swagger JSON file, follow these steps:

1. Run your application in the development environment.

2. Navigate to the Swagger JSON endpoint: `http://localhost:5000/swagger/v1/swagger.json` (adjust the URL based on your development environment).

3. Save the Swagger JSON file.

Now, you have a Swagger JSON file that you can use with tools like Swagger UI or import into other documentation platforms to showcase your API endpoints.

## Conclusion

By following these steps, you've successfully integrated feature flags into your ASP.NET Core web application using Microsoft Feature Management. Additionally, you've set up Swagger documentation to make your API easily understandable and testable. This approach allows you to control and roll out new features dynamically while providing clear documentation for developers. Experiment with different feature flag configurations and explore Swagger capabilities to enhance your application's development and deployment process.
