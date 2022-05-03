using System.Reflection;

namespace SimpleApi;

public static class Extensions
{
    public static WebApplication Build(this WebApplicationBuilder builder, SimpleApiSettings settings)
    {
        var assemblies = settings.ActiveAssemblies;
        InterfaceMethods.AddServiceDefinitions(builder.Services, assemblies);
        var webApp = builder.Build();
        InterfaceMethods.AddEndpointDefinitions(webApp, assemblies);
        return webApp;
    }

    public static void AddServiceDefinitions(this IServiceCollection services, IEnumerable<Assembly> assemblies) =>
        InterfaceMethods.AddServiceDefinitions(services, assemblies);

    public static void AddEndpointDefinitions(this WebApplication app, IEnumerable<Assembly> assemblies) =>
        InterfaceMethods.AddEndpointDefinitions(app, assemblies);
}