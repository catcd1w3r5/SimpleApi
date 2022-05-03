using System.Reflection;

namespace SimpleApi;

public sealed class SimpleApiSettings
{
    public List<Assembly> ActiveAssemblies { get; init; }
    public void ClearAssemblies() => ActiveAssemblies.Clear();
    public void AddAssemblies(params Assembly[] assemblies) => ActiveAssemblies.AddRange(assemblies);

    public SimpleApiSettings()
    {
        ActiveAssemblies = new List<Assembly>();
    }
}