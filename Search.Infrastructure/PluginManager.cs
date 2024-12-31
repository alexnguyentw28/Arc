using System.Reflection;
using Shared;

namespace Search.Infrastructure;

public class PluginManager
{
    private PluginLoadContext _loadContext;
    private ISearchPlugin _plugin;

    public ISearchPlugin LoadPlugin(string pluginPath)
    {
        _loadContext = new PluginLoadContext(pluginPath);
        Assembly pluginAssembly = _loadContext.LoadFromAssemblyPath(pluginPath);

        var pluginType = pluginAssembly.GetTypes()
            .FirstOrDefault(t => typeof(ISearchPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        if (pluginType == null)
        {
            throw new InvalidOperationException("No valid plugin type found.");
        }

        _plugin = (ISearchPlugin)Activator.CreateInstance(pluginType);
        return _plugin;
    }

    public void UnloadPlugin()
    {
        _plugin = null;
        _loadContext.Unload();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}