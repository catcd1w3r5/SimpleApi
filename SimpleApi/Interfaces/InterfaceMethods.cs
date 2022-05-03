using System.Reflection;

namespace SimpleApi;

internal static class InterfaceMethods
{
    internal static void AddServiceDefinitions(IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        var endpointServiceInstances = GetInterfaces<IServiceInterface>(assemblies);
        foreach (var endpointDefinition in endpointServiceInstances) endpointDefinition.DefineServices(services);
    }

    internal static void AddEndpointDefinitions(WebApplication app, IEnumerable<Assembly> assemblies)
    {
        var endpointDefinitionsInstances = GetInterfaces<IEndpointInterface>(assemblies);
        foreach (var endpointDefinition in endpointDefinitionsInstances) endpointDefinition.DefineEndpoints(app);
    }

    private static List<T> GetInterfaces<T>(IEnumerable<Assembly> assemblies)
    {
        var definitionsInstances = new List<T>();
        foreach (var assembly in assemblies)
        {
            var definitions = assembly
                .GetTypes()
                .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<T>();
            definitionsInstances.AddRange(definitions);
        }

        return definitionsInstances;
    }
}