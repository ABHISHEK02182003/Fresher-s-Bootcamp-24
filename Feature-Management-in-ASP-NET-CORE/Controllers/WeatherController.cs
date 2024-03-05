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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IFeatureManager _featureManager;

        // Inject IFeatureManager in the constructor
        public WeatherController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();

            // Check if the FeatureRain feature is enabled
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
