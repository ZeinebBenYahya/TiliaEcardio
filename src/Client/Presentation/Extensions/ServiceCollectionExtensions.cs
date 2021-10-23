using System.Windows.Media;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Components;
using Presentation.Utils;

namespace Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPresentationServices(this IServiceCollection services)
        {
            services.AddScoped<MainPanel>();
            services.AddSingleton<ColorsUtil>();
            services.AddSingleton<SelectionUtil>();
            services.AddScoped<BrushConverter>();
        }
    }
}
